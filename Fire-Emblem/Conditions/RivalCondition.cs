using Fire_Emblem.Characters;

namespace Fire_Emblem.Conditions;

public class RivalCondition : Condition
{
    private readonly SingleCondition _condition;
    
    public RivalCondition(SingleCondition condition)
        => _condition = condition;
    public override bool DoesHold(CharacterController character, CharacterController rival)
        => _condition.DoesHold(rival);
}