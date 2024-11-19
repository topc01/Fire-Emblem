using Fire_Emblem.Characters;
using Fire_Emblem.Types;

namespace Fire_Emblem.Effects;

public abstract class BaseEffect
{
    protected EffectType Type {
        get;
        init;
    } = EffectType.Stat;
    public abstract void Apply(CharacterController controller, CharacterController rival);

    public void Apply(CharacterController controller, CharacterController rival, EffectType effectType)
    {
        Console.WriteLine($"Type: {Type}");
        if (Type == effectType) Apply(controller, rival);
    }
    protected int Truncate(double value)
        => Convert.ToInt32(Math.Floor(value));
}