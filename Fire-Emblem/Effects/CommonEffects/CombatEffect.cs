using Fire_Emblem.Characters;
using Fire_Emblem.Types;

namespace Fire_Emblem.Effects.CommonEffects;

public class CombatEffect(StatType targetStat, int bonusOrPenalty) : StatModifierEffect(targetStat, bonusOrPenalty)
{
    public override void Apply(CharacterController character)
        => Apply(character.Combat);
}