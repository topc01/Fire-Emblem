namespace Fire_Emblem.Conditions.LogicalConditions;

public class NotCondition : Condition
{
    private readonly Condition _condition;

    public NotCondition(Condition condition)
        => _condition = condition;

    public override bool DoesHold(CombatSummary combatSummary)
        => !_condition.DoesHold(combatSummary);
}