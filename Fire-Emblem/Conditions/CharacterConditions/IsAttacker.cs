using Fire_Emblem.Characters;

namespace Fire_Emblem.Conditions.CharacterConditions;

public class IsAttacker : CharacterCondition
{
    public override bool DoesHold(CharacterController character)
        => character.IsAttacker;
}