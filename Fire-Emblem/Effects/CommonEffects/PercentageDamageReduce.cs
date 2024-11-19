using Fire_Emblem.Characters;
using Fire_Emblem.Types;

namespace Fire_Emblem.Effects.CommonEffects;

public class PercentageDamageReduce(int value, BattleStage stage = BattleStage.Combat, EffectType type = EffectType.PercentageReduction) : BaseEffect
{
    protected override EffectType Type { get; set; } = type;

    public override void Apply(CharacterController controller, CharacterController rival)
    {
        int reduction = CalculateReduction(controller, rival);
        if (stage == BattleStage.Combat)
            controller.Combat.PercentageDamageReduction = reduction;
        else if (stage == BattleStage.FirstAttack)
            controller.FirstAttack.PercentageDamageReduction = reduction;
        else controller.FollowUp.PercentageDamageReduction = reduction;
    }
    
    protected virtual int CalculateReduction(CharacterController controller, CharacterController rival)
        => value;
    
}