using Fire_Emblem.Characters;
using Fire_Emblem.Types;

namespace Fire_Emblem.Effects.CommonEffects;

public class ExtraDamage(int value, BattleStage stage = BattleStage.Combat) : BaseEffect
{
    public override void Apply(CharacterController controller, CharacterController rival)
    {
        int damage = CalculateDamage(controller, rival);
        if (stage == BattleStage.Combat)
            controller.Combat.ExtraDamage += damage;
        else if (stage == BattleStage.FirstAttack)
            controller.FirstAttack.ExtraDamage += damage;
        else
            controller.FollowUp.ExtraDamage += damage;
    }

    protected virtual int CalculateDamage(CharacterController controller, CharacterController rival)
        => value;
}