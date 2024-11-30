using Fire_Emblem.Characters;

namespace Fire_Emblem.Conditions.CharacterConditions;

public class HealthPercentageLessThan(int percentage) : CharacterCondition
{
    public override bool DoesHold(CharacterController controller)
        => Round((double)controller.Character.Hp / controller.Character.MaxHp) * 100 < percentage;
}