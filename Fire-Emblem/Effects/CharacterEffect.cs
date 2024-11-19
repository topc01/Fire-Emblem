using Fire_Emblem.Characters;

namespace Fire_Emblem.Effects;

public abstract class CharacterEffect : BaseEffect
{
    public override void Apply(CharacterController character, CharacterController rival)
        => Apply(character);
    public abstract void Apply(CharacterController controller);
}