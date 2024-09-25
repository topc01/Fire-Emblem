using Fire_Emblem.Characters;

namespace Fire_Emblem.Conditions;

public abstract class SingleCondition : Condition
{
    public override bool DoesHold(CharacterController character, CharacterController rival)
        => DoesHold(character);
    public abstract bool DoesHold(CharacterController character);
}