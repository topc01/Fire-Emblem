using Fire_Emblem.Characters;

namespace Fire_Emblem.Conditions.CharacterConditions;

public class HealthPercentageEquals(int percentage) : CharacterCondition
{
    public override bool DoesHold(CharacterController controller)
        => Truncate((double)controller.Character.Hp / controller.Character.MaxHp * 100) == _percentage;
}