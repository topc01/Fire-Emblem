using Fire_Emblem.Characters;
using Fire_Emblem.Types;

namespace Fire_Emblem.Effects.CommonEffects;

public class PercentageDamageReduce : CharacterEffect
{
    private readonly int _reduction;
    private readonly BattleStage _stage;

    public PercentageDamageReduce(int reduction)
    {
        _reduction = reduction;
        _stage = BattleStage.Combat;
    }

    public PercentageDamageReduce(BattleStage stage, int reduction)
    {
        _reduction = reduction;
        _stage = stage;
    }
    public override void Apply(CharacterController controller)
    {
        if (_stage == BattleStage.Combat)
            controller.Combat.PercentageDamageReduction = _reduction;
        else if (_stage == BattleStage.FirstAttack)
            controller.FirstAttack.PercentageDamageReduction = _reduction;
        else controller.FollowUp.PercentageDamageReduction = _reduction;
        
    }
}