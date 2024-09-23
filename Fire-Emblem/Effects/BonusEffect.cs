using Fire_Emblem.Characters;

namespace Fire_Emblem.Effects;

public class BonusEffect : Effect
{
    private readonly StatType _targetStat;
    private readonly int _bonus;

    public BonusEffect(StatType targetStat, int bonus)
    {
        _targetStat = targetStat;
        _bonus = bonus;
    }

    public override void Apply(CharacterStats characterStats)
    {
        switch (_targetStat)
        {
            case StatType.Atk:
                characterStats.Atk += _bonus;
                break;
            case StatType.Def:
                characterStats.Def += _bonus;
                break;
            case StatType.Res:
                characterStats.Res += _bonus;
                break;
            case StatType.Spd:
                characterStats.Spd += _bonus;
                break;
        }
    }
}