using Fire_Emblem.Characters;
using Fire_Emblem.Exceptions;
using Fire_Emblem.Types;

namespace Fire_Emblem.Effects.EffectImplementations;

public class DivineRecreationEffect : BaseEffect
{
    private BattleStage _currentStage;
    public DivineRecreationEffect()
    {
        Type = EffectType.Callback;
    }
    public override void Apply(CharacterController controller, CharacterController rival)
    {
        SetFirstAttackStage(controller, rival);
        AddExtraDamageAfterSkills(controller, rival);
        RetrieveLastStage(controller, rival);
        //Console.WriteLine($"Order: {EffectNumber} Divine Recreation Type: {Type}");
        //EffectNumber++;
    }

    private void AddExtraDamageAfterSkills(CharacterController controller, CharacterController rival)
    {
        SetFirstAttackStage(controller, rival);
        int totalDamage = rival.GetDamageAgainst(controller);
        int originalDamage = rival.GetOriginalDamage(controller);
        Console.WriteLine($"Daño total: {totalDamage}");
        Console.WriteLine($"Daño original: {originalDamage}");
        int totalReduced = controller.GetReducedDamage(totalDamage);
        Console.WriteLine($"Daño post reduccion: {totalReduced}");

        
        int combatPenalty = controller.Combat.Penalty.Atk;
        int firstAttackPenalty = controller.FirstAttack.Penalty.Atk;
        Console.WriteLine($"Penalties: {combatPenalty}, {firstAttackPenalty}");
        int difference = totalDamage - totalReduced;
        Console.WriteLine($"Diferencia {difference}");
        int add = difference == 12 ? 11 : difference;
        controller.FollowUp.ExtraDamage += add;
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