using Fire_Emblem.Characters;

namespace Fire_Emblem.Conditions;

public abstract class Condition
{
    public abstract bool DoesHold(CharacterController character, CharacterController rival);
    protected int Round(double value)
        => Convert.ToInt32(Math.Floor(value));
}