using Fire_Emblem.Characters;

namespace Fire_Emblem.Effects.EffectImplementations;

public class ExtraChivalry2Effect : CharacterEffect
{
    public override void Apply(CharacterController controller)
    {
        int health = controller.Character.Health;
        int maxHealth = controller.Character.MaxHp;
        int percentage = health / maxHealth;
        int reduction = Truncate(percentage * 0.5);
        controller.Combat.PercentageDamageReduction = reduction;
    }
}