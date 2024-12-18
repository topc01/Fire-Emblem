using Fire_Emblem.Characters;

namespace Fire_Emblem.Effects.CommonEffects;

public class AbsolutDamageReduce(int value) : CharacterEffect
{
    public override void Apply(CharacterController controller)
    {
        controller.Combat.AbsoluteDamageReduction += value;
    }
}