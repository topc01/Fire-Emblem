using Fire_Emblem.Characters;

namespace Fire_Emblem.Effects;

public class BonusEffect : StatModifierEffect
{
    public BonusEffect(StatType targetStat, int bonus) : base(targetStat, bonus){}
    public override void Apply(CharacterController character)
    {
        switch (TargetStat)
        {
            case StatType.Atk:
                character.Bonus.Atk = Bonus;
                break;
            case StatType.Def:
                character.Bonus.Def = Bonus;
                break;
            case StatType.Res:
                character.Bonus.Res = Bonus;
                break;
            case StatType.Spd:
                character.Bonus.Spd = Bonus;
                break;
        }
    }
}