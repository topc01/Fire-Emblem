using Fire_Emblem.Characters;
using Fire_Emblem.Types;

namespace Fire_Emblem.Effects.CommonEffects;

public abstract class StatModifierEffect : CharacterEffect
{
    private readonly StatType TargetStat;
    private readonly int Bonus;
    protected StatModifierEffect(StatType targetStat, int bonus)
    {
        TargetStat = targetStat;
        Bonus = bonus;
    }
    protected void Apply(StatModificator statModificator)
    {
        switch (TargetStat)
        {
            case StatType.Atk:
                statModificator.Atk = Bonus;
                break;
            case StatType.Def:
                statModificator.Def = Bonus;
                break;
            case StatType.Res:
                statModificator.Res = Bonus;
                break;
            case StatType.Spd:
                statModificator.Spd = Bonus;
                break;
        }
    }
}