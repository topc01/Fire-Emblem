namespace Fire_Emblem;

public class Character
{
    private readonly CharacterStats _character;
    public readonly List<Skill> Skills = new();
    public Character(CharacterStats characterStats)
    {
        _character = characterStats.New();
    }
    public CharacterStats GetStats => _character;
    public bool IsAlive() => _character.Health > 0;
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
    public override string ToString() => $"{_character.Name} ({_character.Health})";
    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;
        
        Character other = (Character)obj;
        return _character.Name == other._character.Name;
    }
    public string Name => _character.Name;
    public override int GetHashCode() => HashCode.Combine(_character.Name);
}