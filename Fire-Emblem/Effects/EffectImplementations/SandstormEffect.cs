using Fire_Emblem.Characters;

namespace Fire_Emblem.Effects.EffectImplementations;

public class SandstormEffect : CharacterEffect
{
    public override void Apply(CharacterController controller)
    {
        double z = controller.Character.Def * 1.5;
        int x = Round(z - controller.Character.Atk);
        BonusOrPenalty(controller, x).FollowUp.Atk = x;
    }
}