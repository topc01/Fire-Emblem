using Fire_Emblem.Characters;
using Fire_Emblem.Types;

namespace Fire_Emblem.Conditions.CharacterConditions;

public class StatGreaterThanRival(StatType stat) : Condition
{
    public override bool DoesHold(CharacterController character, CharacterController rival)
        => character.GetStatWithoutSpecificModificators(stat) > rival.GetStatWithoutSpecificModificators(stat);
}