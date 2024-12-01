using Fire_Emblem.Characters;

namespace Fire_Emblem.Conditions.CharacterConditions;

public class HealthPercentageRoundedGreaterThan(int percentage) : CharacterCondition
{
    public override bool DoesHold(CharacterController controller)
    {
        double healthRatio = (double)controller.Character.Hp / controller.Character.MaxHp;
        double healthPercentage = Round(healthRatio);
        return healthPercentage >= percentage * 0.01;
    }
}