using Fire_Emblem.Characters;
using Fire_Emblem.Types;

namespace Fire_Emblem.Effects.EffectImplementations;

public class LunarBraceEffect : BaseEffect
{
    public LunarBraceEffect()
    {
        Type = EffectType.Callback;
    }
    
    public override void Apply(CharacterController controller, CharacterController rival)
    {
        int rivalDef = rival.GetStatWithoutSpecificModificators(StatType.Def);
        int pondered = Truncate(rivalDef * 0.3);
        controller.Combat.ExtraDamage += pondered;
    }
}