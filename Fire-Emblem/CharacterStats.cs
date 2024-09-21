namespace Fire_Emblem;

public class CharacterStats : ICloneable
{
    public required string Name { get; set; }
    public required string Weapon
    {
        init => Armament = Armament.GetArmamentFromName(value);
        get => Armament.Name;
    }
    public required string Gender { get; set; }
    public required string DeathQuote { get; set; }
    public required string HP
    {
        init
        {
            _maxHp = Convert.ToInt32(value);
            _health = _maxHp;
        }
    }
    public required int Atk { get; set; }
    public required int Spd { get; set; }
    public required int Def { get; set; }
    public required int Res { get; set; }
    
    public readonly List<Skill> Skills = new ();
    public readonly Armament Armament;
    private readonly int _maxHp;
    public int Health
    {
        set => _health = int.Max(0, int.Min(_maxHp, value));
        get => _health;
    }
    private int _health;
    public object Clone() => this.MemberwiseClone();
    public CharacterStats New() => (CharacterStats)Clone();
}