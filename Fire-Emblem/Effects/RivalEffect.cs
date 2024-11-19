using Fire_Emblem.Characters;

namespace Fire_Emblem.Effects;

public class RivalEffect(BaseEffect effect) : BaseEffect
{
    public override void Apply(CharacterController character, CharacterController rival)
        => effect.Apply(rival, character);
}