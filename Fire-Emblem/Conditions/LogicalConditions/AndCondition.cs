namespace Fire_Emblem.Conditions.LogicalConditions;

public class AndCondition : Condition
{
    private readonly Condition[] _conditions;

    public AndCondition(params Condition[] conditions)
        => _conditions = conditions;

    public override bool DoesHold(CombatSummary combatSummary)
    {
        foreach (Condition condition in _conditions)
            if (!condition.DoesHold(combatSummary))
                return false;
        return true;
    }

}