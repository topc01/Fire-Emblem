using Fire_Emblem.Characters;

namespace Fire_Emblem.Effects.EffectImplementations;

public class GuardBearing2Effect : BaseEffect
{
    public override void Apply(CharacterController controller, CharacterController rival)
    {
        bool isFirstTimeAttacking = controller.IsFirstTimeAttacking();
        bool isFirstTimeDefending = controller.IsFirstTimeDefending();
        Console.WriteLine($" Attacking: {isFirstTimeAttacking}, {controller.Character.AttackingTimes}");
        Console.WriteLine($" Defending: {isFirstTimeDefending}, {controller.Character.DefendingTimes}");
        int reduction = isFirstTimeAttacking || isFirstTimeDefending ? 60 : 30;
        controller.Combat.PercentageDamageReduction = reduction;
    }
}