using Fire_Emblem.Characters;
using Fire_Emblem.Types;

namespace Fire_Emblem.Effects.CommonEffects;

public class HealingEffect: CharacterEffect
{
    private readonly BattleStage[] _stages;
    private readonly int _factor;

    public HealingEffect(int factor, BattleStage stage)
    {
        _stages = new[] { stage };
        _factor = factor;
    }
    public HealingEffect(int factor)
    {
        _stages = new[] { BattleStage.FirstAttack, BattleStage.FollowUp };
        _factor = factor;
    }
    public override void Apply(CharacterController controller)
    {
        if (_stages.Contains(BattleStage.FirstAttack))
            controller.FirstAttack.HealingFactor += _factor;
        if (_stages.Contains(BattleStage.FollowUp))
            controller.FollowUp.HealingFactor += _factor;
    }
}