namespace Fire_Emblem;

public class CharacterController
{
    private CharacterStats? _character;
    public CharacterStats Character
    {
        set => _character = value;
        get => _character ?? throw new InvalidOperationException("Character is not initialized.");
    }
    public string Attack(CharacterController defender)
    {
        int damage = DamageAgainst(defender);
        defender.ReceiveDamage(damage);
        return $"{Name} ataca a {defender.Name} con {damage} de daño";
    }
    private int DamageAgainst(CharacterController opponent)
    {
        int atk = Character.Atk;
        Armament armament = Character.Armament;
        double advantage = armament.GetAdvantage(opponent.Character.Armament);
        double defense = armament.IsMagic() ? opponent.Character.Res : opponent.Character.Def;
        return int.Max((int)(atk * advantage - defense), 0);
    }
    //private int Res => _character.Res;
    //private int Def => _character.Def;
    //private int Spd => _character.Spd;
    //private int Health => _character.Health;
    private string WeaponName => Character.Weapon;
    private string Name => Character.Name;
    public bool IsAlive() => Character.Health > 0;
    public bool CanFollowUp(CharacterController opponent) => Character.Spd - opponent.Character.Spd >= 5;
    private void ReceiveDamage(int damage) => Character.Health -= damage;
    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;
        CharacterStats other = (CharacterStats)obj;
        return Name == other.Name;
    }
    public override int GetHashCode() => HashCode.Combine(Name);
    public void AddSkills(Skill[] skills)
    {
        foreach (var skill in skills)
        {
            Character.Skills.Add(skill);
        }
    }
    private bool HasRepeatedSkills() => Character.Skills.Count != Character.Skills.Distinct().Count();
    private bool HasMoreThan2Skills() => Character.Skills.Count > 2;
    public bool IsValidCharacter() => !HasRepeatedSkills() && !HasMoreThan2Skills();
    public string CheckAdvantages(CharacterController opponent)
    {
        Armament armament = Character.Armament;
        double advantage = armament.GetAdvantage(opponent.Character.Armament);
        return advantage switch
        {
            1.0 => "Ninguna unidad tiene ventaja con respecto a la otra",
            > 1.0 => $"{Name} ({WeaponName}) tiene ventaja con respecto a {opponent.Name} ({opponent.WeaponName})",
            < 1.0 => $"{opponent.Name} ({opponent.WeaponName}) tiene ventaja con respecto a {Name} ({WeaponName})",
            _ => throw new Exception($"Unknown advantage for {WeaponName} and {opponent.WeaponName}")
        };
    }
    public override string ToString() => $"{Name} ({Character.Health})";
}