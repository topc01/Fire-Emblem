namespace Fire_Emblem.Conditions.LogicalConditions;

public class Not : Condition
{
    private readonly Condition _condition;

    public Not(Condition condition)
        => _condition = condition;

    public override bool DoesHold(CombatSummary combatSummary)
        => !_condition.DoesHold(combatSummary);
}