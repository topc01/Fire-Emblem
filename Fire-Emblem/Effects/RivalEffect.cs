using Fire_Emblem.Characters;

namespace Fire_Emblem.Effects;

public class RivalEffect(CharacterEffect effect) : BaseEffect
{

    public override void Apply(CharacterController character, CharacterController rival)
        => effect.Apply(rival);
}