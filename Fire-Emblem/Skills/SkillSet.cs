using Fire_Emblem.Characters;
using Fire_Emblem.Types;

namespace Fire_Emblem.Skills;

public class SkillSet(Skill? firstSkill, Skill? secondSkill)
{
    private readonly Skill _firstSkill = firstSkill ?? new Skill();
    private readonly Skill _secondSkill = secondSkill ?? new Skill();

    public static SkillSet FromSkillList(List<Skill> skills)
    {
        Skill? skill1 = skills.Count > 0 ? skills[0] : null; 
        Skill? skill2 = skills.Count > 1 ? skills[1] : null;
        return new SkillSet(skill1, skill2);
    }
    public void ApplyIfDoesHold(CharacterController controller, CharacterController rival)
    {
        ApplyEffectsType(controller, rival, EffectType.Stat);
        ApplyEffectsType(controller, rival, EffectType.ExtraDamage);
        ApplyEffectsType(controller, rival, EffectType.PercentageReduction);
        ApplyEffectsType(controller, rival, EffectType.AbsolutReduction);
        ApplyEffectsType(controller, rival, EffectType.Callback);
    }

    public void ApplyEffectsType(CharacterController controller, CharacterController rival, EffectType type)
    {
        _firstSkill.ApplyIfDoesHold(controller, rival, type);
        _secondSkill.ApplyIfDoesHold(controller, rival, type);
    }
    
}