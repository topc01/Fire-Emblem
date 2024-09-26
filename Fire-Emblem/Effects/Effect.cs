using Fire_Emblem.Characters;

namespace Fire_Emblem.Effects;

public abstract class Effect
{
    public abstract void Apply(CharacterController character, CharacterController rival);
    protected int Round(double value)
        => Convert.ToInt32(Math.Floor(value));
    protected StatModificator BonusOrPenalty(CharacterController character, int value)
        => value > 0 ? character.Bonus : character.Penalty;
}