using Fire_Emblem.Characters;
using Fire_Emblem.Types;

namespace Fire_Emblem.Effects.CommonEffects;

public class BonusNeutralizer(params StatType[] stats) : CharacterEffect
{
    private readonly StatType[] _stats = stats.Length > 0 ? stats : new[] { StatType.Atk, StatType.Def, StatType.Res, StatType.Spd };

    public override void Apply(CharacterController controller)
    {
        foreach (StatType stat in _stats)
            controller.NeutralizeAllStatBonus(stat);
    }
}