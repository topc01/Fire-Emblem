using Fire_Emblem.Characters;

namespace Fire_Emblem.Effects.EffectImplementations;

public class IgnisEffect : CharacterEffect
{
    public override void Apply(CharacterController controller)
        => controller.Bonus.FirstAttack.Atk += controller.Character.Atk / 2;
}