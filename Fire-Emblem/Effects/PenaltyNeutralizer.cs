using Fire_Emblem.Characters;

namespace Fire_Emblem.Effects;

public class PenaltyNeutralizer : CharacterEffect
{
    private readonly StatType[] _stats;

    public PenaltyNeutralizer(params StatType[] stats)
        => _stats = stats;

    public PenaltyNeutralizer()
        => _stats = new[] { StatType.Atk, StatType.Def, StatType.Res, StatType.Spd };

    public override void Apply(CharacterController controller)
    {
        foreach (StatType stat in _stats)
            controller.Bonus.Neutralize(stat);
    }
}