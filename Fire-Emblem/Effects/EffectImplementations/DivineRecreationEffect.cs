using Fire_Emblem.Characters;
using Fire_Emblem.Exceptions;
using Fire_Emblem.Types;

namespace Fire_Emblem.Effects.EffectImplementations;

public class DivineRecreationEffect : Effect
{
    private BattleStage _currentStage;
    public override void Apply(CharacterController controller, CharacterController rival)
    {
        rival.Combat.Atk = -4;
        rival.Combat.Spd = -4;
        rival.Combat.Def = -4;
        rival.Combat.Res = -4;
        controller.FirstAttack.PercentageDamageReduction = 30;
        /*BattleStage stage = controller.Stage;
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

        SetFirstAttackStage(controller, rival);
        int totalDamage = rival.GetDamageAgainst(controller);
        Console.WriteLine($"Daño total: {totalDamage}");
        int totalReduced = controller.ReduceDamage(totalDamage);
        Console.WriteLine($"Daño reducido: {totalReduced}");
        int difference = totalDamage - totalReduced;
        Console.WriteLine($"Diferencia {difference}");
        nextStage.ExtraDamage += difference;
        Console.WriteLine($"Daño extra: {nextStage.ExtraDamage}");
        RetrieveLastStage(controller, rival);*/
        // rival.SkillsAppliedCallback = AddExtraDamageAfterSkills;
        controller.AddCallback(AddExtraDamageAfterSkills);
    }

    private void AddExtraDamageAfterSkills(CharacterController controller, CharacterController rival)
    {
        SetFirstAttackStage(controller, rival);
        int totalDamage = rival.GetDamageAgainst(controller);
        Console.WriteLine($"Daño total: {totalDamage}");
        int totalReduced = controller.ReduceDamage(totalDamage);
        Console.WriteLine($"Daño reducido: {totalReduced}");
        int difference = totalDamage - totalReduced;
        Console.WriteLine($"Diferencia {difference}");
        controller.FollowUp.ExtraDamage += difference;
        Console.WriteLine($"Daño extra: {controller.FollowUp.ExtraDamage}");
        RetrieveLastStage(controller, rival);
    }

    private void SetFirstAttackStage(CharacterController controller, CharacterController rival)
    {
        BattleStage controllerStage = controller.Stage;
        BattleStage rivalStage = rival.Stage;
        if (controllerStage != rivalStage)
            throw new StagesOutOfSync();
        _currentStage = controllerStage;
        controller.Stage = BattleStage.FirstAttack;
        rival.Stage = BattleStage.FirstAttack;
    }

    private void RetrieveLastStage(CharacterController controller, CharacterController rival)
    {
        controller.Stage = _currentStage;
        rival.Stage = _currentStage;
    }
}