using Fire_Emblem.Characters;
using Fire_Emblem.Types;

namespace Fire_Emblem.Effects;

public class CombatEffect : StatModifierEffect
{
    public CombatEffect(StatType targetStat, int bonusOrPenalty) : base(targetStat, bonusOrPenalty){}
    public override void Apply(CharacterController character)
        => Apply(character.Combat);
}