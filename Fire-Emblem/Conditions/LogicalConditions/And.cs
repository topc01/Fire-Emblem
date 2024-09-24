namespace Fire_Emblem.Conditions.LogicalConditions;

public class And : Condition
{
    private readonly Condition[] _conditions;

    public And(params Condition[] conditions)
        => _conditions = conditions;

    public override bool DoesHold(CombatSummary combatSummary)
    {
        foreach (Condition condition in _conditions)
            if (!condition.DoesHold(combatSummary))
                return false;
        return true;
    }

}