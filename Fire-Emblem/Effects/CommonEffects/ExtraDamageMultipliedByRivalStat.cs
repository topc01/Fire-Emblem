using Fire_Emblem.Characters;
using Fire_Emblem.Types;

namespace Fire_Emblem.Effects.CommonEffects;

public class ExtraDamageMultipliedByRivalStat(StatType stat, int factor, BattleStage stage = BattleStage.Combat) : ExtraDamage(0, stage)
{
    protected override int CalculateDamage(CharacterController controller, CharacterController rival)
    {
        int rivalStat = rival.GetStatWithoutSpecificModificators(stat);
        return Truncate(rivalStat * factor * 0.01);
    }
}