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
                character.Bonus.Atk.Combat += Bonus;
                break;
            case StatType.Def:
                character.Bonus.Def.Combat += Bonus;
                break;
            case StatType.Res:
                character.Bonus.Res.Combat += Bonus;
                break;
            case StatType.Spd:
                character.Bonus.Spd.Combat += Bonus;
                break;
        }
    }
}