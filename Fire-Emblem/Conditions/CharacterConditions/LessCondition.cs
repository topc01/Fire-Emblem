using Fire_Emblem.Characters;

namespace Fire_Emblem.Conditions.CharacterConditions;

public class LessCondition : SingleCondition
{
    private readonly StatType _stat;
    private readonly int _threshold;

    public LessCondition(StatType target, int threshold)
    {
        _stat = target;
        _threshold = threshold;
    }
    public override bool DoesHold(CharacterController character)
        => character.GetStat(_stat) < _threshold;

}