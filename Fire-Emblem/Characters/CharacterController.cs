

using Fire_Emblem.Skills;

namespace Fire_Emblem.Characters;

public class CharacterController
{
    private CharacterStats? _character;
    public List<Skill> Skills = new();
    public StatModificator Bonus = new('+');
    public StatModificator Penalty = new('-');
    public bool GuaranteedFollowUp = false;
    public bool NegatedFollowUp = false;
    
    public CharacterStats Character
    {
        private set => _character = value;
        get => _character ?? throw new InvalidOperationException("Character is not initialized.");
    }
    public void SetCharacter(Character character)
    {
        Character = character.CharacterS;
        Skills = character.Skills;
    }
    public string Fight(CharacterController defender)
    {
        int damage = DamageAgainst(defender);
        defender.ReceiveDamage(damage);
        return $"{Character.Name} ataca a {defender.Character.Name} con {damage} de daño";
    }
    private int DamageAgainst(CharacterController opponent)
    {
        int atk = Character.Atk;
        Armament armament = Character.Armament;
        double advantage = armament.GetAdvantage(opponent.Character.Armament);
        double rivalDefense = armament.IsMagic() ? opponent.Character.Res : opponent.Character.Def;
        return int.Max((int)(atk * advantage - rivalDefense), 0);
    }
    public bool IsAlive() => HP > 0;
    public bool CanFollowUp(CharacterController opponent)
        => (IsFaster(opponent) && !NegatedFollowUp) || GuaranteedFollowUp;
    private bool IsFaster(CharacterController opponent) => Character.Spd - opponent.Character.Spd >= 5;
    private void ReceiveDamage(int damage) => HP -= damage;
    public string CheckAdvantages(CharacterController opponent)
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
    public override string ToString() => $"{Character.Name} ({HP})";

    public int HP
    {
        get => Character.Health;
        set => Character.Health = value;
    }

    public int BaseHp
    {
        get => Character.MaxHp;
        set => Character.MaxHp = value;
    }

    public void Reset()
    {
        Bonus = new('+');
        Penalty = new('-');
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

    public bool IsAttacker;

    public bool IsLastRival(CharacterController opponent)
        => Character.LastRival == opponent.Character;

    private Func<string, string> Message(string message = "")
        => (string value) => $"{Character.Name} obtiene {value}{message}";

    public string[] Logs
        => GetModifierLogs(Bonus)
            .Concat(GetModifierLogs(Penalty))
            .Concat(GetNeutralizedModifierLogs(Bonus)
                .Select(str => $"Los bonus {str}"))
            .Concat(GetNeutralizedModifierLogs(Penalty)
                .Select(str => $"Los penalty {str}"))
            .ToArray();

    public string[] GetModifierLogs(StatModificator modificator)
        => modificator.CombatMsg
            .Select(Message())
            .Concat(Bonus.FirstAttackMsg
                .Select(Message(" en su primer ataque")))
            .Concat(Bonus.FollowUpMsg
                .Select(Message(" en su Follow-Up")))
            .ToArray();

    public string[] GetNeutralizedModifierLogs(StatModificator modificator)
        => new[]
        {
            modificator.Atk.IsNeutralized ? $"de Atk de {Character.Name} fueron neutralizados" : null,
            modificator.Spd.IsNeutralized ? $"de Spd de {Character.Name} fueron neutralizados" : null,
            modificator.Def.IsNeutralized ? $"de Def de {Character.Name} fueron neutralizados" : null,
            modificator.Res.IsNeutralized ? $"de Res de {Character.Name} fueron neutralizados" : null,
        }.Where(str => str != null).ToArray()!;
}