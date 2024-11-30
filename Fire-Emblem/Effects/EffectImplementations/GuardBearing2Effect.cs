using Fire_Emblem.Characters;

namespace Fire_Emblem.Effects.EffectImplementations;

public class GuardBearing2Effect : BaseEffect
{
    public override void Apply(CharacterController controller, CharacterController rival)
    {
        bool isFirstTimeAttacking = controller.IsFirstTimeAttacking();
        bool isRivalsFirstTimeAttacking = rival.IsFirstTimeAttacking();
        int reduction = isFirstTimeAttacking || isRivalsFirstTimeAttacking ? 60 : 30;
        controller.Combat.PercentageDamageReduction = reduction;
    }
}