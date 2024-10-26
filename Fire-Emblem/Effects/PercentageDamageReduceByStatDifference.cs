using Fire_Emblem.Characters;
using Fire_Emblem.Types;

namespace Fire_Emblem.Effects;

public class PercentageDamageReduceByStatDifference(StatType stat, int factor = 4, int max = int.MaxValue) : Effect
{
    public override void Apply(CharacterController controller, CharacterController rival)
    {
        int controllerStat = controller.GetStatWithoutSpecificModificators(stat);
        int rivalStat = rival.GetStatWithoutSpecificModificators(stat);
        int difference = controllerStat - rivalStat;
        int reduction = int.Min(difference * factor, max);
        controller.Combat.PercentageDamageReduction = reduction;
        Console.WriteLine($"ACAAAA {reduction}");
    }
}