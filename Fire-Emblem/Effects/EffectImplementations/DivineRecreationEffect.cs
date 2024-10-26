using Fire_Emblem.Characters;

namespace Fire_Emblem.Effects.EffectImplementations;

public class DivineRecreationEffect : Effect
{
    public override void Apply(CharacterController controller, CharacterController rival)
    {
        rival.Combat.Atk = -4;
        rival.Combat.Spd = -4;
        rival.Combat.Def = -4;
        rival.Combat.Res = -4;
        controller.FirstAttack.PercentageDamageReduction = 30;
    }
}