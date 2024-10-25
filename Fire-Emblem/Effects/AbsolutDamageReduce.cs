using Fire_Emblem.Characters;

namespace Fire_Emblem.Effects;

public class AbsolutDamageReduce(int quantity) : CharacterEffect
{
    public override void Apply(CharacterController controller)
    {
        controller.Combat.AbsoluteDamageReduction = quantity;
    }
}