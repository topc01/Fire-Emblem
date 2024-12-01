using Fire_Emblem.Characters;

namespace Fire_Emblem.Effects.CommonEffects;

public class NeutralizeCounterAttackNegation : CharacterEffect
{
    public override void Apply(CharacterController controller)
    {
        controller.Combat.NegationNegated = true;
    }
}