using Fire_Emblem.Characters;

namespace Fire_Emblem.Effects;

public abstract class Effect
{
    public abstract void Apply(CharacterController controller, CharacterController rival);
    protected int Truncate(double value)
        => Convert.ToInt32(Math.Floor(value));
}