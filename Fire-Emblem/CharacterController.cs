namespace Fire_Emblem;

public class CharacterController
{
    private readonly CharacterStats _character;
    public CharacterController(CharacterStats character)
    {
        _character = character;
    }
    public string Attack(CharacterController defender)
    {
        int damage = DamageAgainst(defender);
        defender.ReceiveDamage(damage);
        return $"{Name} ataca a {defender.Name} con {damage} de daño";
    }
    private int DamageAgainst(CharacterController opponent)
    {
        int atk = _character.Atk;
        double advantage = Armament.GetAdvantage(opponent.Armament);
        double defense = Armament.IsMagic() ? opponent.Res : opponent.Def;
        return int.Max((int)(atk * advantage - defense), 0);
    }
    private Armament Armament => _character.Armament;
    private int Res => _character.Res;
    private int Def => _character.Def;
    private int Spd => _character.Spd;
    private int Health => _character.Health;
    private string WeaponName => _character.WeaponName;
    private string Name => _character.Name;
    public bool IsAlive => _character.Health > 0;
    public bool CanFollowUp(CharacterController opponent) => Spd - opponent.Spd >= 5;
    private void ReceiveDamage(int damage) => _character.Health -= damage;
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
            _character.Skills.Add(skill);
        }
    }
    private bool HasRepeatedSkills() => _character.Skills.Count != _character.Skills.Distinct().Count();
    private bool HasMoreThan2Skills() => _character.Skills.Count > 2;
    public bool IsValidCharacter() => !HasRepeatedSkills() && !HasMoreThan2Skills();
    public string CheckAdvantages(CharacterController opponent)
    {
        double advantage = Armament.GetAdvantage(opponent.Armament);
        return advantage switch
        {
            1.0 => "Ninguna unidad tiene ventaja con respecto a la otra",
            > 1.0 => $"{Name} ({WeaponName}) tiene ventaja con respecto a {opponent.Name} ({opponent.WeaponName})",
            < 1.0 => $"{opponent.Name} ({opponent.WeaponName}) tiene ventaja con respecto a {Name} ({WeaponName})",
            _ => throw new Exception($"Unknown advantage for {WeaponName} and {opponent.WeaponName}")
        };
    }
    public override string ToString() => $"{Name} ({Health})";
}