using Fire_Emblem.Characters;

namespace Fire_Emblem.Conditions.LogicalConditions;

public class NotCondition : Condition
{
    private readonly Condition _condition;

    public NotCondition(Condition condition)
        => _condition = condition;

    public override bool DoesHold(CharacterController character, CharacterController rival)
        => !_condition.DoesHold(character, rival);
}