using Fire_Emblem.Characters;
using Fire_Emblem.Types;

namespace Fire_Emblem.Effects.CommonEffects;

public class ExtraDamage(int value, BattleStage stage = BattleStage.Combat) : CharacterEffect
{
    public override void Apply(CharacterController controller)
    {
        if (stage == BattleStage.Combat)
            controller.Combat.ExtraDamage += value;
        else if (stage == BattleStage.FirstAttack)
            controller.FirstAttack.ExtraDamage += value;
        else
            controller.FollowUp.ExtraDamage += value;
    }
}