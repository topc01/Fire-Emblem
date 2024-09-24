namespace Fire_Emblem.Conditions.LogicalConditions;

public class Or : Condition
{
    private readonly Condition[] _conditions;

    public Or(params Condition[] conditions)
        => _conditions = conditions;

    public override bool DoesHold(CombatSummary combatSummary)
    {
        foreach (Condition condition in _conditions)
            if (condition.DoesHold(combatSummary))
                return true;
        return false;
    }
}