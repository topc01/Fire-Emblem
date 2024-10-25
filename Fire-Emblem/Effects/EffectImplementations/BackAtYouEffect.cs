using Fire_Emblem.Characters;

namespace Fire_Emblem.Effects.EffectImplementations;

public class BackAtYouEffect() : CharacterEffect
{
    public override void Apply(CharacterController controller)
    {
        int initialHealth = controller.Character.MaxHp;
        int actualHealth = controller.Character.Health;
        int healthLost = initialHealth - actualHealth;
        controller.Combat.ExtraDamage += Round(healthLost * 0.5);
    }
}