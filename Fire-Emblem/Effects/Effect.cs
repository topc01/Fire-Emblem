using Fire_Emblem.Characters;

namespace Fire_Emblem.Effects;

public abstract class Effect
{
    public abstract void Apply(CharacterStats characterStats);
}