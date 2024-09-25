using Fire_Emblem.Characters;

namespace Fire_Emblem.Effects;

public class PenaltyEffect : StatModifierEffect
{
    public PenaltyEffect(StatType targetStat, int penalty) : base(targetStat, penalty){}
    public PenaltyEffect(StatType targetStat, double linearFactor) : base(targetStat, linearFactor){}
    public PenaltyEffect(StatType targetStat, double linearFactor, int constantFactor) : base(targetStat, linearFactor, constantFactor){}
    public override void Apply(CharacterController controller)
    {
        CharacterStats baseStats = controller.Character;
        AttackOrientedModifiedStats stats = controller.Penalty;
        switch (TargetStat)
        {
            case StatType.Atk:
                stats.Atk = Round(baseStats.Atk * LinearFactor + ConstantFactor);
                break;
            case StatType.Def:
                stats.Def = Round(baseStats.Def * LinearFactor + ConstantFactor);
                break;
            case StatType.Res:
                stats.Res = Round(baseStats.Res * LinearFactor + ConstantFactor);
                break;
            case StatType.Spd:
                stats.Spd = Round(baseStats.Spd * LinearFactor + ConstantFactor);
                break;
        }
    }
}
