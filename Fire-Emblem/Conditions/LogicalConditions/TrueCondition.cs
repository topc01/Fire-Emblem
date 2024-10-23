using Fire_Emblem.Characters;

namespace Fire_Emblem.Conditions.LogicalConditions;

public class TrueCondition : Condition
{
    public override bool DoesHold(CharacterController _1, CharacterController _2)
    {
        return true;
    }

}