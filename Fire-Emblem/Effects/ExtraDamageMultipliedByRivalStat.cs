using Fire_Emblem.Characters;
using Fire_Emblem.Types;

namespace Fire_Emblem.Effects;

public class ExtraDamageMultipliedByRivalStat(StatType stat, int factor) : Effect
{
    public override void Apply(CharacterController controller, CharacterController rival)
    {
        int rivalStat = rival.GetStatWithoutSpecificModificators(stat);
        controller.Combat.ExtraDamage += Truncate(rivalStat * factor * 0.01);
    }
}