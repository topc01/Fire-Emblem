namespace Fire_Emblem.Conditions.LogicalConditions;

public class OrCondition : Condition
{
    private readonly Condition[] _conditions;

    public OrCondition(params Condition[] conditions)
        => _conditions = conditions;

    public override bool DoesHold(CombatSummary combatSummary)
    {
        foreach (Condition condition in _conditions)
            if (condition.DoesHold(combatSummary))
                return true;
        return false;
    }
}