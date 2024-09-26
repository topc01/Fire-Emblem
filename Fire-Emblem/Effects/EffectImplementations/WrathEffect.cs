using Fire_Emblem.Characters;

namespace Fire_Emblem.Effects.EffectImplementations;

public class WrathEffect : CharacterEffect
{
    public override void Apply(CharacterController controller)
    {
        int healthLost = controller.BaseHp - controller.HP;
        controller.Bonus.Atk.Combat += int.Min(healthLost, 30);
        controller.Bonus.Spd.Combat += int.Min(healthLost, 30);
    }
}