using Fire_Emblem.Characters;

namespace Fire_Emblem.Conditions.CharacterConditions;

public class HealthPercentageLessThan(int percentage) : CharacterCondition
{
    public override bool DoesHold(CharacterController controller)
    {
        double healthRatio = (double)controller.Character.Hp / controller.Character.MaxHp;
        double healthPercentage = Round(healthRatio * 100);
        return Math.Abs(healthPercentage) < percentage;
    }
}