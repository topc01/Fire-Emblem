using Fire_Emblem.Characters;

namespace Fire_Emblem.Effects;

public abstract class StatModifierEffect : Effect
{
    public override void Apply(CharacterController character, CharacterController rival)
        => Apply(character);
    public abstract void Apply(CharacterController character);
}