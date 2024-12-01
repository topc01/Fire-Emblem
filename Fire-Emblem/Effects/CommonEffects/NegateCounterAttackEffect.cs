using Fire_Emblem.Characters;

namespace Fire_Emblem.Effects.CommonEffects;

public class NegateCounterAttackEffect : CharacterEffect
{
    public override void Apply(CharacterController controller)
    {
        controller.Combat.NegationsNumber++;
    }
}