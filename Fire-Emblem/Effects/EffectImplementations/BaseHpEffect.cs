using Fire_Emblem.Characters;

namespace Fire_Emblem.Effects.EffectImplementations;

public class BaseHpEffect : CharacterEffect
{
    public override void Apply(CharacterController controller)
        => controller.BaseHp += 15;
}