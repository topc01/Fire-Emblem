namespace Fire_Emblem;

public class CharacterAnalyzer
{
    private readonly Character _character;
    private int _hp;
    public CharacterAnalyzer(Character character)
    {
        _character = character;
        _hp = character.HP;
    }
    public bool CanFollowUp(CharacterAnalyzer opponent) => Spd - opponent.Spd >= 5;
    private int Spd => _character.Spd;
    public bool IsAlive => _character.Hp > 0;
    private string Name => _character.Name;

    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;
        Character other = (Character)obj;
        return Name == other.Name;
    }
    public override int GetHashCode() => HashCode.Combine(Name);
    public Character Character => _character;
}