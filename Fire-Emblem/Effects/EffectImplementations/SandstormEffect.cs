using Fire_Emblem.Characters;

namespace Fire_Emblem.Effects.EffectImplementations;

public class SandstormEffect : CharacterEffect
{
    public override void Apply(CharacterController controller)
    {
        double defenseWeightedBy150 = controller.Character.Def * 1.5;
        int differenceWithWeightedDefense = Round(defenseWeightedBy150 - controller.Character.Atk);
        ApplyToBonusOrPenalty(controller, differenceWithWeightedDefense).FollowUp.Atk += differenceWithWeightedDefense;
    }
}