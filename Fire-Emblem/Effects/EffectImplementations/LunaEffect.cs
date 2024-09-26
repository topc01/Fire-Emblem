using Fire_Emblem.Characters;

namespace Fire_Emblem.Effects.EffectImplementations;

public class LunaEffect : CharacterEffect
{
    public override void Apply(CharacterController controller)
    {
        controller.Penalty.Def.FirstAttack += Round(controller.Character.Def * 0.5);
        controller.Penalty.Res.FirstAttack += Round(controller.Character.Res * 0.5);
    }
}