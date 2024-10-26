using Fire_Emblem.Characters;
using Fire_Emblem.Types;

namespace Fire_Emblem.Effects.EffectImplementations;

public class LunarBraceEffect : Effect
{
    public override void Apply(CharacterController controller, CharacterController rival)
    {
        int rivalDef = rival.GetStatWithoutSpecificModificators(StatType.Def);
        controller.Combat.ExtraDamage += Truncate(rivalDef * 0.3);
    }
}