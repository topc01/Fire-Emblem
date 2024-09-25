using Fire_Emblem.Characters;

namespace Fire_Emblem.Effects;

public class BonusEffect : StatModifierEffect
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
                character.Bonus.Atk = _bonus;
                break;
            case StatType.Def:
                character.Bonus.Def = _bonus;
                break;
            case StatType.Res:
                character.Bonus.Res = _bonus;
                break;
            case StatType.Spd:
                character.Bonus.Spd = _bonus;
                break;
        }
    }
}