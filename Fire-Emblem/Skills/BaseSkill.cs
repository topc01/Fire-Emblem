using Fire_Emblem.Characters;

namespace Fire_Emblem.Skills;

public abstract class BaseSkill
{
    public string Name = "";
    public string Description { get; set; } = null!;
    public abstract void ApplyIfDoesHold(CharacterController controller, CharacterController rival);

    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;
        var other = (BaseSkill)obj;
        return Name == other.Name;
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(Name);
    }
}