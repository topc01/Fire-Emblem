using Fire_Emblem.Characters;

namespace Fire_Emblem.Effects.EffectImplementations;

public class GuardBearing2Effect : BaseEffect
{
    public override void Apply(CharacterController controller, CharacterController rival)
    {
        bool isFirstTimeAttacking = controller.Character.FirstTimeAttacking;
        bool isFirstTimeDefending = controller.Character.FirstTimeDefending;
        int reduction = isFirstTimeAttacking || isFirstTimeDefending ? 60 : 30;
        controller.Combat.PercentageDamageReduction = reduction;
    }
}