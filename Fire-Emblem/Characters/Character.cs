using Fire_Emblem.Skills;

namespace Fire_Emblem.Characters;

public class Character
{
    public readonly List<Skill> Skills = new();

    public Character(CharacterStats characterStats)
    {
        CharacterS = characterStats.New();
    }

    public CharacterStats CharacterS { get; }

    public string Name => CharacterS.Name;

    public bool IsAlive()
    {
        return CharacterS.Health > 0;
    }

    public void AddSkills(Skill[] skills)
    {
        foreach (var skill in skills) Skills.Add(skill);
    }

    public bool IsValidCharacter()
    {
        return !HasRepeatedSkills() && !HasMoreThan2Skills();
    }

    private bool HasRepeatedSkills()
    {
        return Skills.Count != Skills.Distinct().Count();
    }

    private bool HasMoreThan2Skills()
    {
        return Skills.Count > 2;
    }

    public override string ToString()
    {
        return $"{CharacterS.Name} ({CharacterS.Health})";
    }

    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        var other = (Character)obj;
        return CharacterS.Name == other.CharacterS.Name;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(CharacterS.Name);
    }
}