using Fire_Emblem.Characters;
using Fire_Emblem.Types;

namespace Fire_Emblem.Effects.CommonEffects;

public class PercentageDamageReduceByStatDifference(StatType stat, int factor = 4, int max = int.MaxValue, BattleStage stage = BattleStage.Combat, EffectType type = EffectType.PercentageReduction) : PercentageDamageReduce(0, stage, type)
{
    protected override int CalculateReduction(CharacterController controller, CharacterController rival)
    {
        int controllerStat = controller.GetStatWithoutSpecificModificators(stat);
        int rivalStat = rival.GetStatWithoutSpecificModificators(stat);
        int difference = controllerStat - rivalStat;
        return int.Min(difference * factor, max);
    }
}