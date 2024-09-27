using Fire_Emblem.Characters;
using Fire_Emblem.Types;

namespace Fire_Emblem.Effects;

public class BonusEffect : StatModifierEffect
{
    public BonusEffect(StatType targetStat, int bonus) : base(targetStat, bonus){}
    public override void Apply(CharacterController character)
        => Apply(character.Bonus);
}