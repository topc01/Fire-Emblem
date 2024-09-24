namespace Fire_Emblem.Conditions.LogicalConditions;

public class TrueCondition : Condition
{
    public override bool DoesHold(CombatSummary _)
        => true;

}