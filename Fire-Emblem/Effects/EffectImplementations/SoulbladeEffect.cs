using Fire_Emblem.Characters;

namespace Fire_Emblem.Effects.EffectImplementations;

public class SoulbladeEffect : CharacterEffect
{
    public override void Apply(CharacterController rival)
    {
        int meanBetweenDefAndRes = (rival.Character.Def + rival.Character.Res) / 2;
        int defDifference = meanBetweenDefAndRes - rival.Character.Def;
        int resDifference = meanBetweenDefAndRes - rival.Character.Res;
        ApplyToBonusOrPenalty(rival, defDifference).Def.Combat += defDifference;
        ApplyToBonusOrPenalty(rival, resDifference).Res.Combat += resDifference;
    }
}