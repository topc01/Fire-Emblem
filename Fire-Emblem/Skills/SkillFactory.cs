using Fire_Emblem.Conditions;
using Fire_Emblem.Conditions.CharacterConditions;
using Fire_Emblem.Conditions.LogicalConditions;
using Fire_Emblem.Effects;
using Fire_Emblem.Effects.EffectImplementations;

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

    private readonly StatType Atk = StatType.Atk;
    private readonly StatType Def = StatType.Def;
    private readonly StatType Res = StatType.Res;
    private readonly StatType Spd = StatType.Spd;

    private Skill? CreateSkill(string name)
    {
        return name switch
        {
            "HP +15" => null,
            "Fair Fight"
                => new Skill(
                    new IsAttacker(),
                    new MultiEffect(
                        new BonusEffect(Atk, 6), new RivalEffect(new BonusEffect(Atk, 6)))),
            "Will to win" => null,
            "Single-Minded" => null,
            "Ignis" => null,
            "Perceptive" => null,
            "Tome Precision"
                => new Skill(
                    new WeaponCondition(Armament.Magic),
                    new MultiEffect(
                        new BonusEffect(Atk, 6), new BonusEffect(Spd, 6))),
            "Attack +6" 
                => new Skill(
                    new BonusEffect(Atk, 6)),
            "Speed +5" 
                => new Skill(
                new BonusEffect(Spd, 5)),
            "Defense +5" 
                => new Skill(
                new BonusEffect(Def, 5)),
            "Wrath" => null,
            "Resolve" => null,
            "Resistance +5"
                => new Skill(
                    new BonusEffect(Res, 5)),
            "Atk/Def +5"
                => new Skill(
                    new MultiEffect(
                        new BonusEffect(Atk, 5), new BonusEffect(Def, 5))),
            "Atk/Res +5"
                => new Skill(
                    new MultiEffect(
                        new BonusEffect(Atk, 5), new BonusEffect(Res, 5))),
            "Spd/Res +5"
                => new Skill(
                    new MultiEffect(
                        new BonusEffect(Spd, 5), new BonusEffect(Res, 5))),
            "Deadly Blade"
                => new Skill(
                    new AndCondition(
                        new IsAttacker(), new WeaponCondition(Armament.Sword)),
                    new MultiEffect(
                        new BonusEffect(Atk, 8), new BonusEffect(Spd, 8))),
            "Death Blow"
                => new Skill(
                new IsAttacker(),
                        new BonusEffect(Atk, 8)),
            "Armored Blow"
                => new Skill(
                    new IsAttacker(),
                            new BonusEffect(Def, 8)),
            "Darting Blow"
                => new Skill(
                    new IsAttacker(),
                    new BonusEffect(Spd, 8)),
            "Warding Blow"
                => new Skill(
                    new IsAttacker(),
                    new BonusEffect(Res, 8)),
            "Swift Sparrow"
                => new Skill(
                    new IsAttacker(),
                    new MultiEffect(
                        new BonusEffect(Atk, 6), new BonusEffect(Spd, 6))),
            "Sturdy Blow"
                => new Skill(
                    new IsAttacker(),
                    new MultiEffect(
                        new BonusEffect(Atk, 6), new BonusEffect(Def, 6))),
            "Mirror Strike"
                => new Skill(
                    new IsAttacker(),
                    new MultiEffect(
                        new BonusEffect(Atk, 6), new BonusEffect(Res, 6))),
            "Steady Blow"
                => new Skill(
                    new IsAttacker(),
                    new MultiEffect(
                        new BonusEffect(Spd, 6), new BonusEffect(Def, 6))),
            "Swift Strike"
                => new Skill(
                    new IsAttacker(),
                    new MultiEffect(
                        new BonusEffect(Spd, 6), new BonusEffect(Res, 6))),
            "Bracing Blow"
                => new Skill(
                    new IsAttacker(),
                    new MultiEffect(
                        new BonusEffect(Res, 6), new BonusEffect(Def, 6))),
            "..." => null,
            "Chaos Style"
                => new Skill(
                    new OrCondition(
                        new AndCondition(
                            new NotCondition(new WeaponCondition(Armament.Magic)),
                            new RivalCondition(new WeaponCondition(Armament.Magic))
                            ),
                        new AndCondition(
                            (new WeaponCondition(Armament.Magic)),
                            new NotCondition(new RivalCondition(new WeaponCondition(Armament.Magic)))
                        )
                        ),
                    new BonusEffect(Spd, 3)),
            "Blinding Flash"
                => new Skill(
                    new IsAttacker(),
                    new RivalEffect(new PenaltyEffect(Spd, 4))),
            "Not *Quite*"
                => new Skill(
                    new RivalCondition(new IsAttacker()),
                    new RivalEffect(new PenaltyEffect(Atk, 4))),
            "Stunning Smile"
                => new Skill(
                    new RivalCondition(new IsMale()),
                    new RivalEffect(new PenaltyEffect(Spd, 8))),
            "Disarming Sigh"
                => new Skill(
                    new RivalCondition(new IsMale()),
                    new RivalEffect(new PenaltyEffect(Atk, 8))),
            "Charmer"
                => new Skill(
                    new IsLastRival(),
                    new MultiEffect(
                        new RivalEffect(new PenaltyEffect(Atk, 3)), 
                        new RivalEffect(new PenaltyEffect(Spd, 3)))),
            "Luna"
                => new Skill(new LunaEffect()),
            _ => null
        };
        
    }
}