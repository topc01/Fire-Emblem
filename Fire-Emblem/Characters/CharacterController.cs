

namespace Fire_Emblem.Characters;

public class CharacterController
{
    private CharacterStats? _character;
    //private List<Skill>? _skills;
    public readonly AttackOrientedModifiedStats Bonus = new();
    public readonly AttackOrientedModifiedStats Penalty = new();
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
        //_skills = character.Skills;
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
        Bonus.Reset();
        Penalty.Reset();
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

}