using Fire_Emblem.Characters;
using Fire_Emblem.Types;

namespace Fire_Emblem.Effects.CommonEffects;

public class PercentageDamageReduce(int reduction, BattleStage stage = BattleStage.Combat, EffectType type = EffectType.PercentageReduction) : CharacterEffect
{
    private readonly int _reduction;
    private readonly BattleStage _stage;

    public override void Apply(CharacterController controller)
    {
        if (stage == BattleStage.Combat)
            controller.Combat.PercentageDamageReduction = reduction;
        else if (stage == BattleStage.FirstAttack)
            controller.FirstAttack.PercentageDamageReduction = reduction;
        else controller.FollowUp.PercentageDamageReduction = reduction;
    }
}