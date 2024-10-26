using Fire_Emblem.Characters;
using Fire_Emblem.Types;

namespace Fire_Emblem.Effects.EffectImplementations;

public class DragonsWrathEffect : Effect
{
    public override void Apply(CharacterController controller, CharacterController rival)
    {
        int rivalRes = rival.GetStatWithoutSpecificModificators(StatType.Res);
        int atk = controller.GetStatWithoutSpecificModificators(StatType.Atk);
        int difference = atk - rivalRes;
        controller.FirstAttack.ExtraDamage += Truncate(difference * 0.25);
    }
}