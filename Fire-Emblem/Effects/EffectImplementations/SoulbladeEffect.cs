using Fire_Emblem.Characters;

namespace Fire_Emblem.Effects.EffectImplementations;

public class SoulbladeEffect : CharacterEffect
{
    public override void Apply(CharacterController rival)
    {
        int mean = (rival.Character.Def + rival.Character.Res) / 2;
        int defDifference = mean - rival.Character.Def;
        int resDifference = mean - rival.Character.Res;
        BonusOrPenalty(rival, defDifference).Def.Combat += defDifference;
        BonusOrPenalty(rival, resDifference).Res.Combat += resDifference;
    }
}