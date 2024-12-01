using Fire_Emblem.Effects.CommonEffects;
using Fire_Emblem.Types;

namespace Fire_Emblem.Effects;

public static class EffectBuilder
{
    public static BaseEffect BuildBonusToAllStats(int value)
        => new MultiEffect(
            new CombatEffect(StatType.Atk, value),
            new CombatEffect(StatType.Spd, value),
            new CombatEffect(StatType.Def, value),
            new CombatEffect(StatType.Res, value)
            );
}