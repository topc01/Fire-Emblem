using Fire_Emblem.Characters;
using Fire_Emblem.Conditions;
using Fire_Emblem.Conditions.LogicalConditions;
using Fire_Emblem.Effects;
using Fire_Emblem.Types;

namespace Fire_Emblem.Skills;

public class Skill : BaseSkill
{
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
    
    public override void ApplyIfDoesHold(CharacterController character, CharacterController rival)
    {
        if (_condition.DoesHold(character, rival))
            _effect.Apply(character, rival);
    }
    public void ApplyIfDoesHold(CharacterController character, CharacterController rival, EffectType type)
    {
        if (_condition.DoesHold(character, rival))
            _effect.Apply(character, rival, type);
    }

    
}