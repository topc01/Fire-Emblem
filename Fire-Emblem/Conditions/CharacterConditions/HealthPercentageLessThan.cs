using Fire_Emblem.Characters;

namespace Fire_Emblem.Conditions.CharacterConditions;

public class HealthPercentageLessThan : SingleCondition
{
    private readonly int _percentage;

    public HealthPercentageLessThan(int percentage)
        => _percentage = percentage;
    public override bool DoesHold(CharacterController controller)
        => controller.HP / controller.BaseHp * 100 < _percentage;
}