using Fire_Emblem.Characters;

namespace Fire_Emblem.Conditions.CharacterConditions;

public class HealthPercentageEquals : SingleCondition
{
    private readonly int _percentage;

    public HealthPercentageEquals(int percentage)
        => _percentage = percentage;
    public override bool DoesHold(CharacterController controller)
        => controller.HP / controller.BaseHp * 100 == _percentage;
}