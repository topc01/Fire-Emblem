using Fire_Emblem.Characters;

namespace Fire_Emblem.Conditions.CharacterConditions;

public class IsLastRival : Condition
{
    public override bool DoesHold(CharacterController controller, CharacterController opponent)
        => controller.IsLastRival(opponent);
}