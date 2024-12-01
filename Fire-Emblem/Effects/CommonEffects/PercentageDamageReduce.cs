using Fire_Emblem.Characters;
using Fire_Emblem.Types;

namespace Fire_Emblem.Effects.CommonEffects;

public class PercentageDamageReduce : BaseEffect
{
    private readonly BattleStage _stage;
    private readonly int _value;

    public PercentageDamageReduce(int value, BattleStage stage = BattleStage.Combat,
        EffectType type = EffectType.PercentageReduction)
    {
        Type = type;
        _stage = stage;
        _value = value;
    }

    public override void Apply(CharacterController controller, CharacterController rival)
    {
        controller.LogStatus('>');
        rival.LogStatus('*');
        int reduction = CalculateReduction(controller, rival);
        if (_stage == BattleStage.Combat)
            controller.Combat.PercentageDamageReduction = reduction;
        else if (_stage == BattleStage.FirstAttack)
            controller.FirstAttack.PercentageDamageReduction = reduction;
        else controller.FollowUp.PercentageDamageReduction = reduction;
        controller.LogStatus('>');
        rival.LogStatus('*');
    }
    
    protected virtual int CalculateReduction(CharacterController controller, CharacterController rival)
        => _value;
    
}