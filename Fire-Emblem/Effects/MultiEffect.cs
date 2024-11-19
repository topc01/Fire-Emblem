using Fire_Emblem.Characters;

namespace Fire_Emblem.Effects;

public class MultiEffect(params BaseEffect[] effects) : BaseEffect
{
    //private readonly BaseEffect[] _effects;

    /*public MultiEffect(params BaseEffect[] effects)
        => _effects = effects;*/

    public override void Apply(CharacterController character, CharacterController rival)
    {
        foreach (var effect in effects)
        {
            effect.Apply(character, rival);
        }
    }
}