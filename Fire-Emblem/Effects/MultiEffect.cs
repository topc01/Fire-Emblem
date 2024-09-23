using Fire_Emblem.Characters;

namespace Fire_Emblem.Effects;

public class MultiEffect : Effect
{
    private readonly Effect[] _effects;

    public MultiEffect(params Effect[] effects)
        => _effects = effects;

    public override void Apply(CharacterStats characterStats)
    {
        foreach (var effect in _effects)
        {
            effect.Apply(characterStats);
        }
    }
}