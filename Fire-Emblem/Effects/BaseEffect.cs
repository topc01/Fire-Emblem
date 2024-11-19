using Fire_Emblem.Characters;

namespace Fire_Emblem.Effects;

public abstract class BaseEffect(EffectType type = EffectType.Stat)
{
    public abstract void Apply(CharacterController controller, CharacterController rival);
    protected int Truncate(double value)
        => Convert.ToInt32(Math.Floor(value));
}