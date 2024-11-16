using Fire_Emblem.Characters;
using Fire_Emblem.Types;

namespace Fire_Emblem.Effects;

public class PenaltyFromBaseStatPercentage(StatType stat, int percentage) : CharacterEffect
{
    public override void Apply(CharacterController controller)
    {
        int baseStat = controller.Character.GetStat(stat);
        int reduction = Truncate(baseStat * percentage * 0.01);
        controller.Combat.Penalty.SetStat(stat, reduction);
    }
}