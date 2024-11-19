using Fire_Emblem.Characters;

namespace Fire_Emblem.Effects.EffectImplementations;

public class ExtraChivalry2Effect : BaseEffect
{
    public override void Apply(CharacterController controller, CharacterController rival)
    {
        int health = rival.Character.Hp;
        int maxHealth = rival.Character.MaxHp;
        int percentage = Truncate((double)health / maxHealth * 100);
        int reduction = Truncate(percentage * 0.5);
        controller.Combat.PercentageDamageReduction = reduction;
    }
}