using Fire_Emblem.Characters;
using Fire_Emblem.Types;

namespace Fire_Emblem.Conditions.CharacterConditions;

public class StatGreaterThanRival : Condition
{
    private readonly StatType _stat;
    private readonly StatType _rivalStat;

    public StatGreaterThanRival(StatType stat)
    {
        _stat = stat;
        _rivalStat = stat;
    }
    public StatGreaterThanRival(StatType stat, StatType rivalStat)
    {
        _stat = stat;
        _rivalStat = rivalStat;
    }
    public override bool DoesHold(CharacterController character, CharacterController rival)
        => character.GetStatWithoutSpecificModificators(_stat) > rival.GetStatWithoutSpecificModificators(_rivalStat);
}