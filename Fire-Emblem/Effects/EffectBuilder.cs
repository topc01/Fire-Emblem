using Fire_Emblem.Effects.CommonEffects;
using Fire_Emblem.Types;

namespace Fire_Emblem.Effects;

public static class EffectBuilder
{
    public static BaseEffect BuildPenaltyToStats(int value, params StatType?[] targetStats)
    {
        BaseEffect? atkPenalty = targetStats.Contains(StatType.Atk) ? new PenaltyEffect(StatType.Atk, value) : null;
        return new MultiEffect(
                targetStats.Contains(StatType.Atk) ? new PenaltyEffect(StatType.Atk, value) : null
            );
    }
}