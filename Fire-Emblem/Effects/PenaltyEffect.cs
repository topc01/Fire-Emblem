using Fire_Emblem.Characters;

namespace Fire_Emblem.Effects;

public abstract class PenaltyEffect : StatModifierEffect
{
    public PenaltyEffect(StatType targetStat, int bonus) : base(targetStat, bonus){}
    public override void Apply(CharacterController character)
        => Apply(character.Penalty);
    public abstract void Apply(AttackOrientedModifiedStats modifiedStats);
}
