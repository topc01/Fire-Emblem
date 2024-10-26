using Fire_Emblem.Characters;

namespace Fire_Emblem.Conditions;

public abstract class Condition
{
    public abstract bool DoesHold(CharacterController character, CharacterController rival);
    protected int Truncate(double value)
        => Convert.ToInt32(Math.Floor(value));

    protected double Round(double value)
        => Math.Round(value, 2);
}