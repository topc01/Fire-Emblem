using Fire_Emblem.Characters;

namespace Fire_Emblem.Conditions.CharacterConditions;

public class HealthPercentageLessThan : CharacterCondition
{
    private readonly int _percentage;

    public HealthPercentageLessThan(int percentage)
        => _percentage = percentage;
    public override bool DoesHold(CharacterController controller)
        => Truncate((double)controller.Character.Hp / controller.Character.MaxHp * 100) < _percentage;
}