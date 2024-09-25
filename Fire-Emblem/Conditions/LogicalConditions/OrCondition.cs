using Fire_Emblem.Characters;

namespace Fire_Emblem.Conditions.LogicalConditions;

public class OrCondition : Condition
{
    private readonly Condition[] _conditions;

    public OrCondition(params Condition[] conditions)
        => _conditions = conditions;

    public override bool DoesHold(CharacterController character, CharacterController rival)
    {
        foreach (Condition condition in _conditions)
            if (condition.DoesHold(character, rival))
                return true;
        return false;
    }
}