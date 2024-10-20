namespace Fire_Emblem.Characters;

public class CharacterStats : ICloneable
{
    public required string Name
    {
        get; set;
    }
    public required string Weapon
    {
        init => Armament = Armament.GetArmamentFromName(value);
        get => Armament.Name;
    }
    public required string Gender
    {
        get; set;
    }
    public required string DeathQuote
    {
        get; set;
    }
    public required string HP
    {
        init
        {
            MaxHp = Convert.ToInt32(value);
            _health = MaxHp;
        }
    }
    public required int Atk
    {
        get; set;
    }
    public required int Spd
    {
        get; set;
    }
    public required int Def
    {
        get; set;
    }
    public required int Res
    {
        get; set;
    }
    public readonly Armament Armament = null!;
    public int MaxHp
    {
        get => _maxHp;
        set
        {
            int currentMaxHp = MaxHp;
            _maxHp = value;
            if (Health == currentMaxHp)
                Health = _maxHp;
        }
    }

    private int _maxHp;
    public int Health
    {
        get => _health;
        set => _health = int.Max(0, int.Min(MaxHp, value));
    }
    private int _health;
    public CharacterStats? LastRival;
    public object Clone() => this.MemberwiseClone();
    public CharacterStats New() => (CharacterStats)Clone();
}