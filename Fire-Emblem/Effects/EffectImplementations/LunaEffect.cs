using Fire_Emblem.Characters;

namespace Fire_Emblem.Effects.EffectImplementations;

public class LunaEffect : CharacterEffect
{
    public override void Apply(CharacterController controller)
    {
        controller.Penalty.FirstAttack.Def = Round(controller.Character.Atk * 0.5);
        controller.Penalty.FirstAttack.Res = Round(controller.Character.Res * 0.5);
    }
}