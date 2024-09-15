namespace Fire_Emblem;

public class Character : ICloneable
{
    public required string Name { get; set; }
    private Armament _armament;
    private string? _weapon;
    public string? Weapon
    {
        get => _weapon;
        set
        {
            _weapon = value;
            _armament = Armament.GetArmamentFromName(value);
        }
    }
    public required string Gender { get; set; }
    public required string DeathQuote { get; set; }
    private int MaxHp { get; set; }
    public required int HP
    {
        get => MaxHp;
        set
        {
            MaxHp = value;
            Hp = MaxHp;
        }
    }
    private int _hp;
    public int Hp
    {
        get => _hp;
        set
        {
            if (value > MaxHp)
                throw new ArgumentOutOfRangeException("La vitalidad no puede ser mayor que el máximo");
            _hp = int.Max(0, value);
        }
    }
    public required int Atk { get; set; }
    public required int Spd { get; set; }
    public required int Def { get; set; }
    public required int Res { get; set; }
    
    public readonly List<Skill> Skills = new List<Skill>();

    public string Attack(Character defender)
    {
        int damage = Damage(defender);
        defender.Hp -= damage;
        return $"{Name} ataca a {defender.Name} con {damage} de daño";
    }
    public bool CanFollowUp(Character opponent) => Spd - opponent.Spd >= 5;

    private int Damage(Character opponent)
        => int.Max((int)(Atk * _armament.GetAdvantage(opponent._armament)) - (_armament.IsMagic() ? opponent.Res : opponent.Def), 0);
        
    public bool IsAlive() => _hp > 0;
    public void AddSkills(Skill[] skills)
    {
        foreach (var skill in skills)
        {
            Skills.Add(skill);
        }
    }
    public bool IsValidCharacter() => !HasRepeatedSkills() && !HasMoreThan2Skills();
    private bool HasRepeatedSkills() => Skills.Count != Skills.Distinct().Count();
    private bool HasMoreThan2Skills() => Skills.Count > 2;
    public string CheckAdvantages(Character opponent)
    {
        double advantage = _armament.GetAdvantage(opponent._armament);
        return advantage switch
        {
            1.0 => "Ninguna unidad tiene ventaja con respecto a la otra",
            > 1.0 => $"{Name} ({Weapon}) tiene ventaja con respecto a {opponent.Name} ({opponent.Weapon})",
            < 1.0 => $"{opponent.Name} ({opponent.Weapon}) tiene ventaja con respecto a {Name} ({Weapon})",
            _ => throw new Exception($"Unknown advantage for {_armament} and {opponent._armament}")
        };
    }

    public override string ToString() => $"{Name} ({_hp})";
    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;
        
        Character other = (Character)obj;
        return Name == other.Name && Atk == other.Atk && Def == other.Def;
    }
    public override int GetHashCode() => HashCode.Combine(Name, Atk, Def);
    public object Clone() => this.MemberwiseClone();
    public Character New() => (Character)Clone();
}