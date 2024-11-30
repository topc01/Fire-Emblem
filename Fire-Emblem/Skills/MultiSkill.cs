using Fire_Emblem.Characters;

namespace Fire_Emblem.Skills;

public class MultiSkill(params Skill[] skills) : Skill
{
    public override void ApplyIfDoesHold(CharacterController character, CharacterController rival, EffectType type)
    {
        foreach (Skill skill in skills)
        {
            skill.ApplyIfDoesHold(character, rival, type);
        }
    }
}