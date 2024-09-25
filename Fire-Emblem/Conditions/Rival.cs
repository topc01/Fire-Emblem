using Fire_Emblem.Characters;

namespace Fire_Emblem.Conditions;

public class Rival : Condition
{
    private readonly SingleCondition _condition;
    
    public Rival(SingleCondition condition)
        => _condition = condition;
    public override bool DoesHold(CharacterController character, CharacterController rival)
        => _condition.DoesHold(rival);
}