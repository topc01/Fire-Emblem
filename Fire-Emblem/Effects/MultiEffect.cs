using Fire_Emblem.Characters;

namespace Fire_Emblem.Effects;

public class MultiEffect : BaseEffect
{
    private readonly BaseEffect[] _effects;

    public MultiEffect(params BaseEffect[] effects)
        => _effects = effects;

    public override void Apply(CharacterController character, CharacterController rival)
    {
        foreach (var effect in _effects)
        {
            effect.Apply(character, rival);
        }
    }
}