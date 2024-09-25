using Fire_Emblem.Characters;
using Fire_Emblem.Conditions;
using Fire_Emblem.Conditions.LogicalConditions;
using Fire_Emblem.Effects;

namespace Fire_Emblem.Skills;

public class Skill
{
    public string Name { get; set; }
    public string Description { get; set; }
    private readonly Condition _condition;
    private readonly Effect _effect;
    public Skill(Condition condition, Effect effect)
    {
        _condition = condition;
        _effect = effect;
    }

    public Skill(Effect effect)
    {
        _effect = effect;
        _condition = new TrueCondition();
    }

    public Skill()
    {
    }
    
    public void ApplyIfDoesHold(CharacterController character, CharacterController rival)
    {
        if (_condition.DoesHold(character, rival))
            _effect.Apply(character, rival);
    }

    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;
        var other = (Skill)obj;
        return Name == other.Name;
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(Name);
    }
}