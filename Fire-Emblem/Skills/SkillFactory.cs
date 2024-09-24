using Fire_Emblem.Conditions.LogicalConditions;
using Fire_Emblem.Effects;

namespace Fire_Emblem.Skills;

public class SkillFactory
{
    public Skill Create(string name)
    {
        Skill? createdSkill = CreateSkill(name);
        if (createdSkill == null)
            createdSkill = new Skill();
        createdSkill.Name = name;
        return createdSkill;
    }

    private Skill? CreateSkill(string name)
    {
        return name switch
        {
            "HP +15" => null,
            "Fair Fight" => null,
            "Will to win" => null,
            "Single-Minded" => null,
            "Ignis" => null,
            "Perceptive" => null,
            "Tome Precision" => null,
            "Attack +6" => new Skill(
                new BonusEffect(StatType.Atk, 6)),
            "Speed +5" => new Skill(
                new BonusEffect(StatType.Spd, 5)),
            "Defense +5" => new Skill(
                new BonusEffect(StatType.Def, 5)),
            "Wrath" => null,
            "Resolve" => null,
            "Resistance +5" => null,
            "Atk/Def +5" => null,
            "Atk/Res +5" => null,
            "Spd/Res +5" => null,
            "Deadly Blade" => null,
            "Death Blow" => null,
            "Armored Blow" => null,
            "Darting Blow" => null,
            _ => null
        };
        
    }
}