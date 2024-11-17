using Fire_Emblem.Characters;

namespace Fire_Emblem.Effects.CommonEffects;

public class FirstAttackDamageReduce(int percentage) : CharacterEffect
{
    public override void Apply(CharacterController controller)
    {
        controller.FirstAttack.PercentageDamageReduction = percentage;
    }
}