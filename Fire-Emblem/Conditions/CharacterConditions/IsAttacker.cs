using Fire_Emblem.Characters;

namespace Fire_Emblem.Conditions.CharacterConditions;

public class IsAttacker : SingleCondition
{
    public override bool DoesHold(CharacterController character)
        => character.IsAttacker;
}