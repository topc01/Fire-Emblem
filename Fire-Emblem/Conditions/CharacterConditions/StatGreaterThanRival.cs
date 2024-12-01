using Fire_Emblem.Characters;
using Fire_Emblem.Types;

namespace Fire_Emblem.Conditions.CharacterConditions;

public class StatGreaterThanRival : Condition
{
    private readonly StatType _stat;
    private readonly StatType _rivalStat;
    private readonly int _difference;

    public StatGreaterThanRival(StatType stat, int diff = 0)
    {
        _stat = stat;
        _rivalStat = stat;
        _difference = diff;
    }
    public StatGreaterThanRival(StatType stat, StatType rivalStat, int diff = 0)
    {
        _stat = stat;
        _rivalStat = rivalStat;
        _difference = diff;
    }
    public override bool DoesHold(CharacterController character, CharacterController rival)
        => character.GetStatWithoutSpecificModificators(_stat) > rival.GetStatWithoutSpecificModificators(_rivalStat) + _difference;
}