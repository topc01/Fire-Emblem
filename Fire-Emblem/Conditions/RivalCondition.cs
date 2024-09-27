using Fire_Emblem.Characters;

namespace Fire_Emblem.Conditions;

public class RivalCondition : Condition
{
    private readonly CharacterCondition _condition;
    
    public RivalCondition(CharacterCondition condition)
        => _condition = condition;
    public override bool DoesHold(CharacterController character, CharacterController rival)
        => _condition.DoesHold(rival);
}