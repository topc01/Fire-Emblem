namespace Fire_Emblem.Characters;

public class CharacterStats : Stats, ICloneable
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
            MaxHp = Convert.ToInt32(value);
            _hp = MaxHp;
        }
    }
    
    public readonly Armament Armament = null!;
    public int MaxHp
    {
        get => _maxHp;
        set
        {
            int currentMaxHp = MaxHp;
            _maxHp = value;
            if (Hp == currentMaxHp)
                Hp = _maxHp;
        }
    }

    private int _maxHp;
    public int Hp
    {
        get => _hp;
        set => _hp = int.Max(0, int.Min(MaxHp, value));
    }
    private int _hp;
    public CharacterStats? LastRival;
    private bool _isAttacker;
    public bool IsAttacker
    {
        get => _isAttacker;
        set
        {
            if (value)
                AttackingTimes += 1;
            if (!value)
                DefendingTimes += 1;
            _isAttacker = value;
        }
    }

    public int AttackingTimes = 0;
    public int DefendingTimes = 0;
    public object Clone() => this.MemberwiseClone();
    public CharacterStats New() => (CharacterStats)Clone();
    private int _startingHealth;
    public int StartingHealth
    {
        get => _startingHealth;
        set => _startingHealth = value;
    }
    public int FirstAttackTotalDamage { get; set; }
}