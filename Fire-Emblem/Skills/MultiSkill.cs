using Fire_Emblem.Characters;
using Fire_Emblem.Types;

namespace Fire_Emblem.Skills;

public class MultiSkill(params Skill[] skills) : Skill
{
    public override void ApplyIfDoesHold(CharacterController character, CharacterController rival, EffectType type)
    {
        character.LogStat('*');
        rival.LogStat('>');
        foreach (Skill skill in skills)
        {
            skill.ApplyIfDoesHold(character, rival, type);
            character.LogStat('*');
            rival.LogStat('>');
        }
    }
}