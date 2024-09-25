using Fire_Emblem.Characters;

namespace Fire_Emblem.Effects;

public abstract class StatModifierEffect : Effect
{
    protected readonly StatType TargetStat;
    protected readonly int Bonus;
    public StatModifierEffect(StatType targetStat, int bonus)
    {
        TargetStat = targetStat;
        Bonus = bonus;
    }
    public override void Apply(CharacterController character, CharacterController rival)
        => Apply(character);
    public abstract void Apply(CharacterController character);
}