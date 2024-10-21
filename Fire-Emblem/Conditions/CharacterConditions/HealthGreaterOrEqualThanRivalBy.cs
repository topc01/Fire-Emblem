using Fire_Emblem.Characters;

namespace Fire_Emblem.Conditions.CharacterConditions;

public class HealthGreaterOrEqualThanRivalBy(int difference) : Condition
{
    public override bool DoesHold(CharacterController controller, CharacterController rival)
        => controller.Character.Health >= rival.Character.Health + difference;
}