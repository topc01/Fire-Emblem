using Fire_Emblem.Characters;

namespace Fire_Emblem.Effects;

public class RivalEffect : Effect
{
    private readonly CharacterEffect _effect;

    public RivalEffect(CharacterEffect effect)
        => _effect = effect;

    public override void Apply(CharacterController character, CharacterController rival)
        => _effect.Apply(rival);
}