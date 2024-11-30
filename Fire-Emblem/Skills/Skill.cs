using Fire_Emblem.Characters;
using Fire_Emblem.Conditions;
using Fire_Emblem.Conditions.LogicalConditions;
using Fire_Emblem.Effects;
using Fire_Emblem.Types;

namespace Fire_Emblem.Skills;

public class Skill : BaseSkill
{
    private readonly Condition _condition;
    private readonly BaseEffect _effect;
    public Skill(Condition condition, BaseEffect effect)
    {
        _condition = condition;
        _effect = effect;
    }

    public Skill(BaseEffect effect)
    {
        _condition = new TrueCondition();
        _effect = effect;
    }

    public Skill()
    {
        _condition = new NotCondition(new TrueCondition());
        _effect = new EmptyEffect();
    }
    
    public override void ApplyIfDoesHold(CharacterController character, CharacterController rival)
    {
        if (_condition.DoesHold(character, rival))
            _effect.Apply(character, rival);
    }
    public virtual void ApplyIfDoesHold(CharacterController character, CharacterController rival, EffectType type)
    {
        if (_condition.DoesHold(character, rival))
            _effect.Apply(character, rival, type);
    }

    
}