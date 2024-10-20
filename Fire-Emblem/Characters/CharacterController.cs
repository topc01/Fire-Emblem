

using Fire_Emblem.Skills;
using Fire_Emblem.Types;

namespace Fire_Emblem.Characters;

public class CharacterController
{
    private CharacterStats? _character;
    public List<Skill> Skills = new();
    public StatModificator Bonus = new('+');
    public StatModificator Penalty = new('-');
    public BattleStage Stage = BattleStage.Preparation;
    private const int SpeedDifferenceRequired = 5;
    public CharacterStats Character
    {
        private set => _character = value;
        get => _character ?? throw new InvalidOperationException("Character is not initialized.");
    }
    
    
    public bool IsAttacker;
    public void SetCharacter(Character character)
    {
        Character = character.Stats;
        Skills = character.Skills;
    }
    public string Attack(CharacterController opponent)
    {
        int damage = GetDamageAgainst(opponent.Character);
        opponent.ReceiveDamage(damage);
        return $"{Character.Name} ataca a {opponent.Character.Name} con {damage} de daño";
    }
    private int GetDamageAgainst(CharacterStats opponent)
    {
        int atk = Character.Atk;
        Armament armament = Character.Armament;
        double advantage = armament.GetAdvantage(opponent.Armament);
        double rivalDefense = armament.IsMagic() ? opponent.Res : opponent.Def;
        return int.Max((int)(atk * advantage - rivalDefense), 0);
    }
    private void ReceiveDamage(int damage) => Character.Health -= damage;
    public bool IsAlive() => Character.Health > 0;
    public bool CanFollowUp(CharacterController opponent)
        => IsFaster(opponent.Character);
    private bool IsFaster(CharacterStats opponent) => Character.Spd - opponent.Spd >= SpeedDifferenceRequired;
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
        Bonus = new('+');
        Penalty = new('-');
        IsAttacker = false;
    }
    public int GetStat(StatType stat)
    {
        return stat switch
        {
            StatType.Atk => Character.Atk,
            StatType.Def => Character.Def,
            StatType.Res => Character.Res,
            StatType.Spd => Character.Spd,
            _ => 0
        };
    }
    public bool IsLastRival(CharacterController opponent)
        => Character.LastRival == opponent.Character;

    public string[] GetLogs()
    {
        string[] bonusLogs = Bonus.GetLogs();
        string[] penaltyLogs = Penalty.GetLogs();
        string[] neutralizedBonusLogs = Bonus.GetNeutralizedLogs();
        string[] neutralizedPenaltyLogs = Penalty.GetNeutralizedLogs();
        IEnumerable<string> logs = bonusLogs
            .Concat(penaltyLogs)
            .Concat(neutralizedBonusLogs)
            .Concat(neutralizedPenaltyLogs);
        IEnumerable<string> logsWithCharacterName = logs.Select((message) => message.Replace("@", Character.Name));
        return logsWithCharacterName.ToArray();
    }

    
}