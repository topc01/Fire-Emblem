using Fire_Emblem.Characters;
using Fire_Emblem.Types;

namespace Fire_Emblem.Conditions.CharacterConditions;

public class LessCondition : CharacterCondition
{
    private readonly StatType _stat;
    private readonly int _threshold;

    public LessCondition(StatType target, int threshold)
    {
        _stat = target;
        _threshold = threshold;
    }
    public override bool DoesHold(CharacterController character)
        => character.GetStatWithoutSpecificModificators(_stat) < _threshold;

}