using Fire_Emblem.Characters;

namespace Fire_Emblem.Effects;

public abstract class StatModifierEffect : Effect
{
    protected readonly StatType TargetStat;
    protected readonly double LinearFactor;
    protected readonly int ConstantFactor;
    public StatModifierEffect(StatType targetStat, int constantFactor)
    {
        TargetStat = targetStat;
        ConstantFactor = constantFactor;
        LinearFactor = 1.0;
    }
    public StatModifierEffect(StatType targetStat, double linearFactor)
    {
        TargetStat = targetStat;
        ConstantFactor = 0;
        LinearFactor = linearFactor;
    }
    public StatModifierEffect(StatType targetStat, double linearFactor, int constantFactor)
    {
        TargetStat = targetStat;
        ConstantFactor = constantFactor;
        LinearFactor = linearFactor;
    }
    public override void Apply(CharacterController character, CharacterController rival)
        => Apply(character);
    public abstract void Apply(CharacterController character);
}