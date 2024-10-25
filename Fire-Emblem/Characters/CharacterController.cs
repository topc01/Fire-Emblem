

using Fire_Emblem.Skills;
using Fire_Emblem.Types;
using Fire_Emblem.Utils;

namespace Fire_Emblem.Characters;

public class CharacterController
{
    private CharacterStats? _character;
    public List<Skill> Skills = new();
    public StatModificator Combat = new();
    public StatModificator FirstAttack = new();
    public StatModificator FollowUp = new();
    
    public BattleStage Stage = BattleStage.FirstAttack;

    private StatModificator CurrentStage
    {
        get
        {
            return Stage switch
            {
                BattleStage.FirstAttack => FirstAttack,
                BattleStage.FollowUp => FollowUp,
                _ => throw new ArgumentException("Stage invalid")
            };
        }
    }
    
    public StatsNeutralizer BonusNeutralizer = new();
    public StatsNeutralizer PenaltyNeutralizer = new();
    private const int SpeedDifferenceRequired = 5;
    public CharacterStats Character
    {
        private set => _character = value;
        get => _character ?? throw new InvalidOperationException("Character is not initialized.");
    }
    
    
    /*
    public bool IsAttacker { get; set; }
    */
    public bool IsAttacker() => Character.IsAttacker;
    public void SetCharacter(Character character)
    {
        Character = character.Stats;
        Skills = character.Skills;
    }
    
    
    public string Attack(CharacterController opponent)
    {
        int damage = GetDamageAgainst(opponent);
        int reducedDamage = opponent.ReceiveDamage(damage);
        return $"{Character.Name} ataca a {opponent.Character.Name} con {reducedDamage} de daño";
    }
    private int GetDamageAgainst(CharacterController opponent)
    {
        int atk = GetTotalStat(StatType.Atk);
        Armament armament = Character.Armament;
        double advantage = armament.GetAdvantage(opponent.Character.Armament);
        StatType rivalDefenseType = armament.IsMagic() ? StatType.Res : StatType.Def;
        double rivalDefense = opponent.GetTotalStat(rivalDefenseType);
        double ponderedAtk = atk * advantage;
        int extraDamage = Combat.ExtraDamage + CurrentStage.ExtraDamage;
        return int.Max((int)(ponderedAtk - rivalDefense + extraDamage), 0);
    }

    private int ReceiveDamage(int damage)
    {
        int newDamage = CurrentStage.ReduceDamage(damage);
        Character.Health -= newDamage;
        return newDamage;
    }
    public bool IsAlive() => Character.Health > 0;
    public bool CanFollowUp(CharacterController opponent)
        => IsFaster(opponent);
    private bool IsFaster(CharacterController opponent) => GetTotalStat(StatType.Spd) - opponent.GetTotalStat(StatType.Spd) >= SpeedDifferenceRequired;
    public string GetAdvantageMessage(CharacterController opponent)
    {
        Armament armament = Character.Armament;
        double advantage = armament.GetAdvantage(opponent.Character.Armament);
        return advantage switch
        {
            1.0 => "Ninguna unidad tiene ventaja con respecto a la otra",
            > 1.0 => $"{Character.Name} ({Character.Weapon}) tiene ventaja con respecto a {opponent.Character.Name} ({opponent.Character.Weapon})",
            < 1.0 => $"{opponent.Character.Name} ({opponent.Character.Weapon}) tiene ventaja con respecto a {Character.Name} ({Character.Weapon})",
            _ => throw new Exception($"Unknown advantage for {Character.Weapon} and {opponent.Character.Weapon}")
        };
    }
    public override string ToString() => $"{Character.Name} ({Character.Health})";
    public void Reset()
    {
        Combat = new();
        FirstAttack = new();
        FollowUp = new();
        BonusNeutralizer = new();
        PenaltyNeutralizer = new();
        Character.IsAttacker = false;
    }
    
    private int GetTotalStat(StatType stat)
    {
        int baseStat = Character.Get(stat);
        int combatStat = Combat.Get(stat);
        int currentStageStat = CurrentStage.Get(stat);
        return baseStat + combatStat + currentStageStat;
    }

    public int GetStatWithoutSpecificModificators(StatType stat)
        => GetTotalStat(stat) - CurrentStage.Get(stat);
    
    public void NeutralizeAllStatBonus(StatType stat)
    {
        BonusNeutralizer.Set(stat, true);
        Combat.BonusNeutralizer.Set(stat, true);
        FirstAttack.BonusNeutralizer.Set(stat, true);
        FollowUp.BonusNeutralizer.Set(stat, true);
    }
    public void NeutralizeAllStatPenalty(StatType stat)
    {
        PenaltyNeutralizer.Set(stat, true);
        Combat.PenaltyNeutralizer.Set(stat, true);
        FirstAttack.PenaltyNeutralizer.Set(stat, true);
        FollowUp.PenaltyNeutralizer.Set(stat, true);
    }
    
    public bool IsLastRival(CharacterController opponent)
        => Character.LastRival == opponent.Character;

    public bool HasAdvantage(CharacterController opponent)
        => Character.Armament.GetAdvantage(opponent.Character.Armament) != 0.0;

    public string[] GetLogs()
    {
        string[] combatBonusLogs = Combat.Bonus.GetLogs();
        string[] combatPenaltyLogs = Combat.Penalty.GetLogs();
        string combatExtraDamageLog = Combat.GetExtraDamageLog();
        string combatPercentageReducedDamageLog = Combat.GetPercentageReducedDamageLog();
        string combatAbsolutReducedDamageLog = Combat.GetAbsolutReducedDamageLog();
        string[] firstAttackPenaltyLogs = FirstAttack.Penalty.GetLogs();
        string firstAttackExtraDamageLog = FirstAttack.GetExtraDamageLog();
        string firstAttackPercentageReducedDamageLog = FirstAttack.GetPercentageReducedDamageLog();
        string[] followUpBonusLogs = FollowUp.Bonus.GetLogs();
        string[] followUpPenaltyLogs = FollowUp.Penalty.GetLogs();
        string followUpExtraDamageLog = FollowUp.GetExtraDamageLog();
        string followUpPercentageReducedDamageLog = FollowUp.GetPercentageReducedDamageLog();
        string[] firstAttackBonusLogs = FirstAttack.Bonus.GetLogs();
        string[] neutralizedBonusLogs = BonusNeutralizer.GetLogs();
        string[] neutralizedPenaltyLogs = PenaltyNeutralizer.GetLogs();

        string combatMessage = "";
        string combatExtraDamageMessage = " en cada ataque";
        string combatReducedDamageMessage = " los ataques";
        string firstAttackMessage = " en su primer ataque";
        string firstAttackReducedDamageMessage = "l primer ataque";
        string followUpMessage = " en su Follow-Up";
        string followUpReducedDamageMessage = "l Follow-Up";
        string[] combatBonusLogsWithMessage = combatBonusLogs.ReplaceMessage(combatMessage);
        string[] combatPenaltyLogsWithMessage = combatPenaltyLogs.ReplaceMessage(combatMessage);
        string combatExtraDamageLogWithMessage = combatExtraDamageLog.Replace("#", combatExtraDamageMessage);
        string combatPercentageReducedDamageLogWithMessage = combatPercentageReducedDamageLog.Replace("#", combatReducedDamageMessage);
        string combatAbsolutReducedDamageLogWithMessage = combatAbsolutReducedDamageLog.Replace("#", combatReducedDamageMessage);
        string[] firstAttackBonusLogsWithMessage = firstAttackBonusLogs.ReplaceMessage(firstAttackMessage);
        string[] firstAttackPenaltyLogsWithMessage = firstAttackPenaltyLogs.ReplaceMessage(firstAttackMessage);
        string firstAttackExtraDamageLogWithMessage = firstAttackExtraDamageLog.Replace("#", firstAttackMessage);
        string firstAttackPercentageReducedDamageLogWithMessage = firstAttackPercentageReducedDamageLog.Replace("#", firstAttackReducedDamageMessage);
        string[] followUpBonusLogsWithMessage = followUpBonusLogs.ReplaceMessage(followUpMessage);
        string[] followUpPenaltyLogsWithMessage = followUpPenaltyLogs.ReplaceMessage(followUpMessage);
        string followUpExtraDamageLogWithMessage = followUpExtraDamageLog.Replace("#", followUpMessage);
        string followUpPercentageReducedDamageLogWithMessage = followUpPercentageReducedDamageLog.Replace("#", followUpReducedDamageMessage);
        
        string[] neutralizedBonusLogsWithBonusMessage = AddLogsSign(neutralizedBonusLogs, "bonus");
        string[] neutralizedPenaltyLogsWithPenaltyMessage = AddLogsSign(neutralizedPenaltyLogs, "penalty");

        List<string> logsList = new();
        logsList.AddManyLogs(
            combatBonusLogsWithMessage,
            firstAttackBonusLogsWithMessage,
            followUpBonusLogsWithMessage,
            combatPenaltyLogsWithMessage,
            firstAttackPenaltyLogsWithMessage,
            followUpPenaltyLogsWithMessage,
            neutralizedBonusLogsWithBonusMessage,
            neutralizedPenaltyLogsWithPenaltyMessage
            );
        logsList.SoftAppend(
            combatExtraDamageLogWithMessage,
            firstAttackExtraDamageLogWithMessage,
            followUpExtraDamageLogWithMessage,
            combatPercentageReducedDamageLogWithMessage,
            firstAttackPercentageReducedDamageLogWithMessage,
            followUpPercentageReducedDamageLogWithMessage,
            combatAbsolutReducedDamageLogWithMessage
            );
        List<string> logsWithCharacterName = logsList.ReplaceName(Character.Name);
        return logsWithCharacterName.ToArray();
    }

    private string[] AddLogsMessage(string[] logs, string message)
        => logs.Select((log) => log.Replace("#", " en su Follow-Up")).ToArray();

    private string[] AddLogsSign(string[] logs, string signName)
        => logs.Select((log) => log.Replace("$", signName)).ToArray();


}