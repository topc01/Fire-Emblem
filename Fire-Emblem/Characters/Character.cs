using Fire_Emblem.Skills;

namespace Fire_Emblem.Characters;

public class Character
{
    public readonly List<Skill> Skills = new();

    public Character(CharacterStats characterStats)
        => Stats = characterStats.New();
    

    public CharacterStats Stats { get; }

    public string Name => Stats.Name;

    public bool IsAlive()
    {
        return Stats.Health > 0;
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
        return $"{Stats.Name} ({Stats.Health})";
    }

    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        var other = (Character)obj;
        return Stats.Name == other.Stats.Name;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Stats.Name);
    }
}