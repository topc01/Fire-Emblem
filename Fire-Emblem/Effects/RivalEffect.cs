using Fire_Emblem.Characters;

namespace Fire_Emblem.Effects;

public class RivalEffect(CharacterEffect effect) : BaseEffect
{
    private readonly CharacterEffect _effect;

    public RivalEffect(CharacterEffect effect)
        => _effect = effect;

    public override void Apply(CharacterController character, CharacterController rival)
        => _effect.Apply(rival);
}