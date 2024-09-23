using Fire_Emblem.Character;

namespace Fire_Emblem.Conditions;

public abstract class Condition
{
    public abstract bool DoesHold(CharacterStats stats);
}