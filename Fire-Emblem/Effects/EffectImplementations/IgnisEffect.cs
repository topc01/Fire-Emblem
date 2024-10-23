using Fire_Emblem.Characters;
using Fire_Emblem.Types;

namespace Fire_Emblem.Effects.EffectImplementations;

public class IgnisEffect : CharacterEffect
{
    public override void Apply(CharacterController controller)
    {
        int baseAtk = controller.Character.Atk;
        controller.FirstAttack.Atk = Round(baseAtk * 0.5);
    }
}