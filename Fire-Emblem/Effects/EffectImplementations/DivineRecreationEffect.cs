using Fire_Emblem.Characters;
using Fire_Emblem.Types;

namespace Fire_Emblem.Effects.EffectImplementations;

public class DivineRecreationEffect : Effect
{
    public override void Apply(CharacterController controller, CharacterController rival)
    {
        rival.Combat.Atk = -4;
        rival.Combat.Spd = -4;
        rival.Combat.Def = -4;
        rival.Combat.Res = -4;
        controller.FirstAttack.PercentageDamageReduction = 30;
        BattleStage stage = controller.Stage;
        StatModificator nextStage = controller.Combat;
        switch (stage)
        {
            case BattleStage.Combat:
                nextStage = controller.FirstAttack;
                break;
            case BattleStage.FirstAttack:
                nextStage = controller.FollowUp;
                break;
        }

        int totalDamage = rival.GetDamageAgainst(controller);
        int totalReduced = controller.ReduceDamage(totalDamage);
        int difference = totalReduced - totalReduced;
        nextStage.ExtraDamage += difference;
    }
}