using Fire_Emblem.Characters;

namespace Fire_Emblem.Conditions.CharacterConditions;

public class IsMale: CharacterCondition
{
    public override bool DoesHold(CharacterController controller)
        => controller.Character.Gender == "Male";
}