using Fire_Emblem.Characters;
using Fire_Emblem.Types;

namespace Fire_Emblem.Effects;

public class PenaltyEffect : StatModifierEffect
{
    public PenaltyEffect(StatType targetStat, int penalty) : base(targetStat, penalty){}
    public override void Apply(CharacterController character)
        => Apply(character.Penalty);
}
