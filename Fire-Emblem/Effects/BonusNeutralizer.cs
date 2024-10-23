using Fire_Emblem.Characters;
using Fire_Emblem.Types;

namespace Fire_Emblem.Effects;

public class BonusNeutralizer : CharacterEffect
{
    private readonly StatType[] _stats;

    public BonusNeutralizer(params StatType[] stats)
        => _stats = stats;

    public BonusNeutralizer()
        => _stats = new[] { StatType.Atk, StatType.Def, StatType.Res, StatType.Spd };

    public override void Apply(CharacterController controller)
    {
        foreach (StatType stat in _stats)
            controller.NeutralizeAllStatBonus(stat);
    }
}