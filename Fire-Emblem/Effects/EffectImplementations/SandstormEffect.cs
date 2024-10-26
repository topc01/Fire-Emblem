using Fire_Emblem.Characters;
using Fire_Emblem.Types;

namespace Fire_Emblem.Effects.EffectImplementations;

public class SandstormEffect : CharacterEffect
{
    public override void Apply(CharacterController controller)
    {
        int def = controller.Character.Def;
        int atk = controller.Character.Atk;
        double defenseWeightedBy150 = def * 1.5;
        int differenceWithWeightedDefense = Truncate(defenseWeightedBy150 - atk);
        controller.FollowUp.Atk = differenceWithWeightedDefense;
    }
}