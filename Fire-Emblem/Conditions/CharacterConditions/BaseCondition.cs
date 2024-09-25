using Fire_Emblem.Characters;

namespace Fire_Emblem.Conditions.CharacterConditions;

public abstract class BaseCondition : Condition
{
    public override bool DoesHold(CharacterController character, CharacterController rival)
        => DoesHold(character);
    public abstract bool DoesHold(CharacterController character);
}