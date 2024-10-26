using Fire_Emblem.Characters;

namespace Fire_Emblem.Effects.EffectImplementations;

public class LunaEffect : CharacterEffect
{
    public override void Apply(CharacterController controller)
    {
        controller.FirstAttack.Def = - Truncate(controller.Character.Def * 0.5);
        controller.FirstAttack.Res = - Truncate(controller.Character.Res * 0.5);
    }
}