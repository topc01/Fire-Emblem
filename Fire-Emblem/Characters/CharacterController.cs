

using Fire_Emblem.Skills;
using Fire_Emblem.Types;

namespace Fire_Emblem.Characters;

public class CharacterController
{
    private CharacterStats? _character;
    private SkillSet? _skills;
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
                // BattleStage.Combat => Combat,
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
        private set
        { 
            _character = value;
            _character.StartingHealth = _character.Hp;
        }
        get => _character ?? throw new InvalidOperationException("Character is not initialized.");
    }
    
    public bool IsAttacker() => Character.IsAttacker;
    public void SetCharacter(Character character)
    {
        Character = character.Stats;
        _skills = SkillSet.FromSkillList(character.Skills);
    }
    
    public string Attack(CharacterController opponent)
    {
        int damage = GetDamageAgainst(opponent);
        int reducedDamage = opponent.ReduceDamage(damage);
        opponent.ReceiveDamage(reducedDamage);
        StoreFirstAttackDamage(reducedDamage);
        return $"{Character.Name} ataca a {opponent.Character.Name} con {reducedDamage} de daño";
    }
    public int GetDamageAgainst(CharacterController opponent)
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

    public int GetOriginalDamage(CharacterController opponent)
    {
        int atk = Character.Atk;
        Armament armament = Character.Armament;
        bool isMagic = armament.IsMagic();
        CharacterStats rival = opponent.Character;
        double rivalDefense = isMagic ? rival.Res : rival.Def;
        double advantage = armament.GetAdvantage(opponent.Character.Armament);
        double ponderedAtk = atk * advantage;
        return int.Max((int)(ponderedAtk - rivalDefense), 0);

    }

    public int GetReducedDamage(int damage)
    {
        int damageAfterCombatPercentageReduction = Combat.ApplyPercentageDamageReduction(damage);
        int damageAfterCurrentStagePercentageReduction = CurrentStage.ApplyPercentageDamageReduction(damageAfterCombatPercentageReduction);
        int damageAfterCombatAbsolutReduction = Combat.ApplyAbsolutDamageReduction(damageAfterCurrentStagePercentageReduction);
        int damageAfterCurrentStageAbsolutReduction = CurrentStage.ApplyAbsolutDamageReduction(damageAfterCombatAbsolutReduction);
        int total = int.Max(damageAfterCurrentStageAbsolutReduction, 0);
        return total;
    }
    private void ReceiveDamage(int damage)
    {
        Character.Hp -= damage;
    }

    private void StoreFirstAttackDamage(int damage)
    {
        if (Stage == BattleStage.FirstAttack)
            Character.FirstAttackTotalDamage = damage;
    }
    public bool IsAlive() => Character.Hp > 0;
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
    public override string ToString() => $"{Character.Name} ({Character.Hp})";
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
        int baseStat = Character.GetStat(stat);
        int combatStat = Combat.GetStatValue(stat);
        int currentStageStat = CurrentStage.GetStatValue(stat);
        return baseStat + combatStat + currentStageStat;
    }

    private int GetModifiersStat(StatType stat)
    {
        int totalStat = GetTotalStat(stat);
        int baseStat = Character.GetStat(stat);
        return totalStat - baseStat;
    }

    public int GetStatWithoutSpecificModificators(StatType stat)
        => GetTotalStat(stat) - CurrentStage.GetStatValue(stat);
    
    public void NeutralizeAllStatBonus(StatType stat)
    {
        BonusNeutralizer.NeutralizeStat(stat);
        Combat.BonusNeutralizer.NeutralizeStat(stat);
        FirstAttack.BonusNeutralizer.NeutralizeStat(stat);
        FollowUp.BonusNeutralizer.NeutralizeStat(stat);
    }
    public void NeutralizeAllStatPenalty(StatType stat)
    {
        PenaltyNeutralizer.NeutralizeStat(stat);
        Combat.PenaltyNeutralizer.NeutralizeStat(stat);
        FirstAttack.PenaltyNeutralizer.NeutralizeStat(stat);
        FollowUp.PenaltyNeutralizer.NeutralizeStat(stat);
    }
    
    public bool IsLastRival(CharacterController opponent)
        => Character.LastRival == opponent.Character;

    public bool HasAdvantage(CharacterController opponent)
        => Character.Armament.GetAdvantage(opponent.Character.Armament) != 0.0;

    public void ApplySkills(CharacterController opponent)
    {
        if (_skills == null) return;
        _skills.ApplyIfDoesHold(this, opponent);
    }

    /*public void SetSkillsAppliedCallback(Action callback)
    {
        SkillsAppliedCallback = callback;
    }*/
}