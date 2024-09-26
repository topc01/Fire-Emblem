using Fire_Emblem.Characters;

namespace Fire_Emblem.Conditions.CharacterConditions;

public class HealthGreaterOrEqualThanRivalBy(int difference) : Condition
{
    public override bool DoesHold(CharacterController character, CharacterController rival)
        => character.HP >= rival.HP + difference;
}