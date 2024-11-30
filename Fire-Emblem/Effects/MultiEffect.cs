using Fire_Emblem.Characters;
using Fire_Emblem.Types;

namespace Fire_Emblem.Effects;

public class MultiEffect(params BaseEffect[] effects) : BaseEffect
{
    //private readonly BaseEffect[] _effects;

    /*public MultiEffect(params BaseEffect[] effects)
        => _effects = effects;*/
    
    
    public override void Apply(CharacterController character, CharacterController rival, EffectType type)
    {
        character.LogStat('*');
        rival.LogStat('>');
        foreach (var effect in effects)
        {
            effect.Apply(character, rival, type);
            character.LogStat('*');
            rival.LogStat('>');
        }
    }
}