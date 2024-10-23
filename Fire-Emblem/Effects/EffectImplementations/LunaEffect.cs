using Fire_Emblem.Characters;

namespace Fire_Emblem.Effects.EffectImplementations;

public class LunaEffect : CharacterEffect
{
    public override void Apply(CharacterController controller)
    {
        controller.FirstAttack.Def = - Round(controller.Character.Def * 0.5);
        controller.FirstAttack.Res = - Round(controller.Character.Res * 0.5);
    }
}