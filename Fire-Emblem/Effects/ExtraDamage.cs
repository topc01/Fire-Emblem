using Fire_Emblem.Characters;
using Fire_Emblem.Types;

namespace Fire_Emblem.Effects;

public class ExtraDamage : CharacterEffect
{
    private readonly int _quantity;
    private readonly BattleStage _stage;
    public ExtraDamage(int quantity)
    {
        _quantity = quantity;
        _stage = BattleStage.Combat;
    }
    public ExtraDamage(BattleStage stage, int quantity)
    {
        _stage = stage;
        _quantity = quantity;
    }
    public override void Apply(CharacterController controller)
    {
        if (_stage == BattleStage.Combat)
            controller.Combat.ExtraDamage += _quantity;
        else if (_stage == BattleStage.FirstAttack)
            controller.FirstAttack.ExtraDamage += _quantity;
        else
            controller.FollowUp.ExtraDamage += _quantity;
    }
}