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
        => Stats.Hp > 0;

    public void AddSkills(Skill[] skills)
    {
        foreach (var skill in skills) 
            Skills.Add(skill);
    }

    public bool IsValidCharacter()
        => !HasRepeatedSkills() && !HasMoreThan2Skills();

    private bool HasRepeatedSkills()
        => Skills.Count != Skills.Distinct().Count();

    private bool HasMoreThan2Skills()
        => Skills.Count > 2;

    public override string ToString()
        => $"{Stats.Name} ({Stats.Hp})";

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