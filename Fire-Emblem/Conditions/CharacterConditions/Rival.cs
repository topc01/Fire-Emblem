using Fire_Emblem.Characters;

namespace Fire_Emblem.Conditions.CharacterConditions;

public class Rival : Condition
{
    private readonly BaseCondition _condition;
    
    public Rival(BaseCondition condition)
        => _condition = condition;
    public override bool DoesHold(CharacterController character, CharacterController rival)
        => _condition.DoesHold(rival);
}