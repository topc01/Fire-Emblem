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

    public override void Apply(CharacterController character)
    {
        switch (_targetStat)
        {
            case StatType.Atk:
                character.Attack += _bonus;
                break;
            case StatType.Def:
                character.Defense += _bonus;
                break;
            case StatType.Res:
                character.Resistance += _bonus;
                break;
            case StatType.Spd:
                character.Speed += _bonus;
                break;
        }
    }
}