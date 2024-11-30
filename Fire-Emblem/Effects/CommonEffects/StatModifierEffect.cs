using Fire_Emblem.Characters;
using Fire_Emblem.Types;

namespace Fire_Emblem.Effects.CommonEffects;

public abstract class StatModifierEffect(StatType targetStat, int value) : CharacterEffect
{
    protected void Apply(StatModificator statModificator)
    {
        switch (targetStat)
        {
            case StatType.Atk:
                statModificator.Atk = value;
                break;
            case StatType.Def:
                statModificator.Def = value;
                break;
            case StatType.Res:
                statModificator.Res = value;
                break;
            case StatType.Spd:
                statModificator.Spd = value;
                break;
        }
    }
}