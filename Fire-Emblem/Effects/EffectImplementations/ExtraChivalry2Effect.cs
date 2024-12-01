using Fire_Emblem.Characters;

namespace Fire_Emblem.Effects.EffectImplementations;

public class ExtraChivalry2Effect : BaseEffect
{
    public override void Apply(CharacterController controller, CharacterController rival)
    {
        int health = rival.Character.Hp;
        int maxHealth = rival.Character.MaxHp;
        double healthRatio = (double)health / maxHealth;
        double healthPercentage = Round(healthRatio * 100);
        int reduction = Truncate(healthPercentage * 0.5);
        controller.Combat.PercentageDamageReduction = reduction;
    }
}