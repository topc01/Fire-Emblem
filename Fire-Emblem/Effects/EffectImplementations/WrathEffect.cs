using Fire_Emblem.Characters;

namespace Fire_Emblem.Effects.EffectImplementations;

public class WrathEffect : CharacterEffect
{
    public override void Apply(CharacterController controller)
    {
        int healthLost = controller.Character.MaxHp - controller.Character.Health;
        controller.Bonus.Combat.Atk += int.Min(healthLost, 30);
        controller.Bonus.Combat.Spd += int.Min(healthLost, 30);
    }
}