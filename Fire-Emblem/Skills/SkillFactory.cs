using Fire_Emblem.Conditions.LogicalConditions;
using Fire_Emblem.Effects;

namespace Fire_Emblem.Skills;

public class SkillFactory
{
    public static Skill? Create(string name)
    {
        if (name == "Attack +6")
            return new Skill(
                new TrueCondition(),
                new BonusEffect(StatType.Atk, 6));
        return null;
    }
}