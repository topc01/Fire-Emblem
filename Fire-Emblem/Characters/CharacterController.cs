

using Fire_Emblem.Skills;
using Fire_Emblem.Types;

namespace Fire_Emblem.Characters;

public class CharacterController
{
    private CharacterStats? _character;
    public List<Skill> Skills = new();
    public StatModificator Combat = new("");
    public StatModificator FirstAttack = new(" en su primer ataque");
    public StatModificator FollowUp = new(" en su Follow-Up");
    
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
        opponent.ReceiveDamage(damage);
        return $"{Character.Name} ataca a {opponent.Character.Name} con {damage} de daño";
    }
    private int GetDamageAgainst(CharacterController opponent)
    {
        int atk = GetTotalStat(StatType.Atk);
        Armament armament = Character.Armament;
        double advantage = armament.GetAdvantage(opponent.Character.Armament);
        StatType rivalDefenseType = armament.IsMagic() ? StatType.Res : StatType.Def;
        double rivalDefense = opponent.GetTotalStat(rivalDefenseType);
        return int.Max((int)(atk * advantage - rivalDefense), 0);
    }
    
    private void ReceiveDamage(int damage) => Character.Health -= damage;
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
        Combat = new("");
        FirstAttack = new(" en su primer ataque");
        FollowUp = new(" en su Follow-Up");
        BonusNeutralizer = new();
        PenaltyNeutralizer = new();
        Character.IsAttacker = false;
    }
    
    private int GetTotalStat(StatType stat)
    {
        return stat switch
        {
            StatType.Atk => Character.Atk + Combat.Atk + CurrentStage.Atk,
            StatType.Spd => Character.Spd + Combat.Spd + CurrentStage.Spd,
            StatType.Def => Character.Def + Combat.Def + CurrentStage.Def,
            StatType.Res => Character.Res + Combat.Res + CurrentStage.Res,
            _ => throw new ApplicationException("Stat unknown")
        };
    }
    public int GetStatWithoutSpecificModificators(StatType stat)
    {
        return stat switch
        {
            StatType.Atk => Character.Atk + Combat.Atk,
            StatType.Spd => Character.Spd + Combat.Spd,
            StatType.Def => Character.Def + Combat.Def,
            StatType.Res => Character.Res + Combat.Res,
            _ => throw new ApplicationException("Stat unknown")
        };
    }

    public void NeutralizeAllStatBonus(StatType stat)
    {
        SetStatNeutralizer(BonusNeutralizer, stat, true);
        SetStatNeutralizer(Combat.BonusNeutralizer, stat, true);
        SetStatNeutralizer(FirstAttack.BonusNeutralizer, stat, true);
        SetStatNeutralizer(FollowUp.BonusNeutralizer, stat, true);
    }
    public void NeutralizeAllStatPenalty(StatType stat)
    {
        SetStatNeutralizer(PenaltyNeutralizer, stat, true);
        SetStatNeutralizer(Combat.PenaltyNeutralizer, stat, true);
        SetStatNeutralizer(FirstAttack.PenaltyNeutralizer, stat, true);
        SetStatNeutralizer(FollowUp.PenaltyNeutralizer, stat, true);
    }

    private void SetStatNeutralizer(StatsNeutralizer neutralizer, StatType stat, bool value)
    {
        switch (stat)
        {
            case StatType.Atk:
                neutralizer.Atk = value;
                break;
            case StatType.Spd:
                neutralizer.Spd = value;
                break;
            case StatType.Def:
                neutralizer.Def = value;
                break;
            case StatType.Res:
                neutralizer.Res = value;
                break;
        }
    }
    
    public bool IsLastRival(CharacterController opponent)
        => Character.LastRival == opponent.Character;

    public string[] GetLogs()
    {
        string[] combatBonusLogs = Combat.Bonus.GetLogs();
        string[] combatPenaltyLogs = Combat.Penalty.GetLogs();
        string[] firstAttackBonusLogs = FirstAttack.Bonus.GetLogs();
        string[] firstAttackPenaltyLogs = FirstAttack.Penalty.GetLogs();
        string[] followUpBonusLogs = FollowUp.Bonus.GetLogs();
        string[] followUpPenaltyLogs = FollowUp.Penalty.GetLogs();
        string[] neutralizedBonusLogs = BonusNeutralizer.GetLogs();
        string[] neutralizedPenaltyLogs = PenaltyNeutralizer.GetLogs();
        
        string[] combatBonusLogsWithMessage = combatBonusLogs.Select((log) => log.Replace("#", "")).ToArray();
        string[] combatPenaltyLogsWithMessage = combatPenaltyLogs.Select((log) => log.Replace("#", "")).ToArray();
        string[] firstAttackBonusLogsWithMessage = firstAttackBonusLogs.Select((log) => log.Replace("#", " en su primer ataque")).ToArray();
        string[] firstAttackPenaltyLogsWithMessage = firstAttackPenaltyLogs.Select((log) => log.Replace("#", " en su primer ataque")).ToArray();
        string[] followUpBonusLogsWithMessage = followUpBonusLogs.Select((log) => log.Replace("#", " en su Follow-Up")).ToArray();
        string[] followUpPenaltyLogsWithMessage = followUpPenaltyLogs.Select((log) => log.Replace("#", " en su Follow-Up")).ToArray();

        string[] neutralizedBonusLogsWithBonusMessage =
            neutralizedBonusLogs.Select((log) => log.Replace("$", "bonus")).ToArray();
        string[] neutralizedPenaltyLogsWithPenaltyMessage =
            neutralizedPenaltyLogs.Select((log) => log.Replace("$", "penalty")).ToArray();

        IEnumerable<string> logs = combatBonusLogsWithMessage
            .Concat(firstAttackBonusLogsWithMessage)
            .Concat(followUpBonusLogsWithMessage)
            .Concat(combatPenaltyLogsWithMessage)
            .Concat(firstAttackPenaltyLogsWithMessage)
            .Concat(followUpPenaltyLogsWithMessage)
            .Concat(neutralizedBonusLogsWithBonusMessage)
            .Concat(neutralizedPenaltyLogsWithPenaltyMessage);
        IEnumerable<string> logsWithCharacterName = logs.Select((message) => message.Replace("@", Character.Name));
        return logsWithCharacterName.ToArray();
    }

    
}