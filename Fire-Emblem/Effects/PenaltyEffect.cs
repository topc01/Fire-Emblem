using Fire_Emblem.Characters;

namespace Fire_Emblem.Effects;

public class PenaltyEffect : StatModifierEffect
{
    public PenaltyEffect(StatType targetStat, int penalty) : base(targetStat, penalty){}
    public override void Apply(CharacterController character)
    {
        switch (TargetStat)
        {
            case StatType.Atk:
                character.Penalty.Atk.Combat += Bonus;
                break;
            case StatType.Def:
                character.Penalty.Def.Combat += Bonus;
                break;
            case StatType.Res:
                character.Penalty.Res.Combat += Bonus;
                break;
            case StatType.Spd:
                character.Penalty.Spd.Combat += Bonus;
                break;
        }
    }
}
