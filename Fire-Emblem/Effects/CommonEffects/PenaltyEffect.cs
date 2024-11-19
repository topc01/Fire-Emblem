using Fire_Emblem.Characters;
using Fire_Emblem.Types;

namespace Fire_Emblem.Effects.CommonEffects;

public class PenaltyEffect(StatType targetStat, int penalty) : StatModifierEffect(targetStat, - penalty)
{
    //public PenaltyEffect(StatType targetStat, int penalty) : base(targetStat, - penalty){}
    public override void Apply(CharacterController character)
        => Apply(character.Combat);
}
