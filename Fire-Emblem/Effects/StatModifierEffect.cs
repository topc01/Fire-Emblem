using Fire_Emblem.Characters;
using Fire_Emblem.Types;

namespace Fire_Emblem.Effects;

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
                statModificator.Combat.Atk += Bonus;
                break;
            case StatType.Def:
                statModificator.Combat.Def += Bonus;
                break;
            case StatType.Res:
                statModificator.Combat.Res += Bonus;
                break;
            case StatType.Spd:
                statModificator.Combat.Spd += Bonus;
                break;
        }
    }
}