using Fire_Emblem.Characters;

namespace Fire_Emblem.Effects.EffectImplementations;

public class PerceptiveEffect : CharacterEffect
{
    public override void Apply(CharacterController controller)
        => controller.Bonus.Spd.Combat += 12 + controller.Character.Spd / 4;
}