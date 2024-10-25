using Fire_Emblem.Characters;

namespace Fire_Emblem.Conditions.CharacterConditions;

public class HasArmamentAdvantage : Condition
{
    public override bool DoesHold(CharacterController character, CharacterController rival)
        => character.HasAdvantage(rival);
}