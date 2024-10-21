using Fire_Emblem.Conditions;
using Fire_Emblem.Conditions.CharacterConditions;
using Fire_Emblem.Conditions.LogicalConditions;
using Fire_Emblem.Effects;
using Fire_Emblem.Effects.EffectImplementations;
using Fire_Emblem.Types;

namespace Fire_Emblem.Skills;

public class SkillFactory
{
    public Skill Create(string name)
    {
        Skill createdSkill = CreateSkill(name);
        createdSkill.Name = name;
        return createdSkill;
    }

    private readonly StatType Atk = StatType.Atk;
    private readonly StatType Def = StatType.Def;
    private readonly StatType Res = StatType.Res;
    private readonly StatType Spd = StatType.Spd;

    private Skill CreateSkill(string name)
    {
        return name switch
        {
            "HP +15"
                => new Skill(new BaseHpEffect()),
            "Fair Fight"
                => new Skill(
                    new IsAttacker(),
                    new MultiEffect(
                        new BonusEffect(Atk, 6), new RivalEffect(new BonusEffect(Atk, 6)))),
            "Will to Win"
                => new Skill(
                    new OrCondition(
                        new HealthPercentageLessThan(50), new HealthPercentageEquals(50)),
                    new BonusEffect(Atk, 8)),
            "Single-Minded"
                => new Skill(
                    new IsLastRival(),
                    new BonusEffect(Atk, 8)),
            "Ignis" 
                => new Skill(new IgnisEffect()),
            "Perceptive"
                => new Skill(
                    new IsAttacker(),
                    new PerceptiveEffect()),
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
            "Wrath"
                => new Skill(new WrathEffect()),
            "Resolve"
                => new Skill(
                    new OrCondition(
                        new HealthPercentageEquals(75), new HealthPercentageLessThan(75)),
                    new MultiEffect(
                        new BonusEffect(Def, 7), new BonusEffect(Res, 7))),
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
            "Brazen Atk/Spd"
                => new Skill(
                    new OrCondition(
                        new HealthPercentageEquals(80), new HealthPercentageLessThan(80)),
                    new MultiEffect(
                        new BonusEffect(Atk, 10), new BonusEffect(Spd, 10))),
            "Brazen Atk/Def"
                => new Skill(
                    new OrCondition(
                        new HealthPercentageEquals(80), new HealthPercentageLessThan(80)),
                    new MultiEffect(
                        new BonusEffect(Atk, 10), new BonusEffect(Def, 10))),
            "Brazen Atk/Res"
                => new Skill(
                    new OrCondition(
                        new HealthPercentageEquals(80), new HealthPercentageLessThan(80)),
                    new MultiEffect(
                        new BonusEffect(Atk, 10), new BonusEffect(Res, 10))),
            "Brazen Spd/Def"
                => new Skill(
                    new OrCondition(
                        new HealthPercentageEquals(80), new HealthPercentageLessThan(80)),
                    new MultiEffect(
                        new BonusEffect(Spd, 10), new BonusEffect(Def, 10))),
            "Brazen Spd/Res"
                => new Skill(
                    new OrCondition(
                        new HealthPercentageEquals(80), new HealthPercentageLessThan(80)),
                    new MultiEffect(
                        new BonusEffect(Spd, 10), new BonusEffect(Res, 10))),
            "Brazen Def/Res"
                => new Skill(
                    new OrCondition(
                        new HealthPercentageEquals(80), new HealthPercentageLessThan(80)),
                    new MultiEffect(
                        new BonusEffect(Def, 10), new BonusEffect(Res, 10))),
            "Fire Boost"
                => new Skill(
                    new HealthGreaterOrEqualThanRivalBy(3),
                    new BonusEffect(Atk, 6)),
            "Wind Boost"
                => new Skill(
                    new HealthGreaterOrEqualThanRivalBy(3),
                    new BonusEffect(Spd, 6)),
            "Earth Boost"
                => new Skill(
                    new HealthGreaterOrEqualThanRivalBy(3),
                    new BonusEffect(Def, 6)),
            "Water Boost"
                => new Skill(
                    new HealthGreaterOrEqualThanRivalBy(3),
                    new BonusEffect(Res, 6)),
            "Chaos Style"
                => new Skill(new AndCondition(
                        new IsAttacker(),
                    new OrCondition(
                        new AndCondition(
                            new NotCondition(new WeaponCondition(Armament.Magic)),
                            new RivalCondition(new WeaponCondition(Armament.Magic))
                            ),
                        new AndCondition(
                            (new WeaponCondition(Armament.Magic)),
                            new NotCondition(new RivalCondition(new WeaponCondition(Armament.Magic)))
                            )
                        )),
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
                => new Skill(new RivalEffect(new LunaEffect())),
            "Belief in Love"
                => new Skill(
                    new OrCondition(
                        new RivalCondition(new IsAttacker()),
                        new RivalCondition(new HealthPercentageEquals(100))),
                    new MultiEffect(
                        new RivalEffect(new PenaltyEffect(Atk, 5)),
                        new RivalEffect(new PenaltyEffect(Def, 5)))),
            "Beorc's Blessing"
                => new Skill(new RivalEffect(new BonusNeutralizer())),
            "Agnea's Arrow"
                => new Skill(new PenaltyNeutralizer()),
            "Soulblade"
                => new Skill(
                    new WeaponCondition(Armament.Sword),
                    new RivalEffect(new SoulbladeEffect())),
            "Sandstorm"
                => new Skill(new SandstormEffect()),
            "Sword Agility"
                => new Skill(
                    new WeaponCondition(Armament.Sword),
                    new MultiEffect(
                        new BonusEffect(Spd, 12), new PenaltyEffect(Atk, 6))),
            "Lance Power"
                => new Skill(
                    new WeaponCondition(Armament.Lance),
                    new MultiEffect(
                        new BonusEffect(Atk, 10), new PenaltyEffect(Def, 10))),
            "Sword Power"
                => new Skill(
                    new WeaponCondition(Armament.Sword),
                    new MultiEffect(
                        new BonusEffect(Atk, 10), new PenaltyEffect(Def, 10))),
            "Bow Focus"
                => new Skill(
                    new WeaponCondition(Armament.Bow),
                    new MultiEffect(
                        new BonusEffect(Atk, 10), new PenaltyEffect(Res, 10))),
            "Lance Agility"
                => new Skill(
                    new WeaponCondition(Armament.Lance),
                    new MultiEffect(
                        new BonusEffect(Spd, 12), new PenaltyEffect(Atk, 6))),
            "Axe Power"
                => new Skill(
                    new WeaponCondition(Armament.Axe),
                    new MultiEffect(
                        new BonusEffect(Atk, 10), new PenaltyEffect(Def, 10))),
            "Bow Agility"
                => new Skill(
                    new WeaponCondition(Armament.Bow),
                    new MultiEffect(
                        new BonusEffect(Spd, 12), new PenaltyEffect(Atk, 6))),
            "Sword Focus"
                => new Skill(
                    new WeaponCondition(Armament.Sword),
                    new MultiEffect(
                        new BonusEffect(Atk, 10), new PenaltyEffect(Res, 10))),
            "Close Def"
                => new Skill(
                    new AndCondition(
                        new RivalCondition(new IsAttacker()),
                        new OrCondition(
                            new RivalCondition(new WeaponCondition(Armament.Sword)),
                            new RivalCondition(new WeaponCondition(Armament.Lance)), 
                            new RivalCondition (new WeaponCondition(Armament.Axe)))),
                    new MultiEffect(
                        new BonusEffect(Def, 8), new BonusEffect(Res, 8), new RivalEffect(new BonusNeutralizer()))),
            "Distant Def"
                => new Skill(
                    new AndCondition(
                        new RivalCondition(new IsAttacker()),
                            new OrCondition(
                                new RivalCondition(new WeaponCondition(Armament.Magic)),
                                new RivalCondition(new WeaponCondition(Armament.Bow)))),
                    new MultiEffect(
                        new BonusEffect(Def, 8), new BonusEffect(Res, 8), new RivalEffect(new BonusNeutralizer()))),
            "Lull Atk/Spd"
                => new Skill(
                    new MultiEffect(
                        new RivalEffect(new PenaltyEffect(Atk, 3)),
                        new RivalEffect(new PenaltyEffect(Spd, 3)),
                        new RivalEffect(new BonusNeutralizer(Atk, Spd))
                        )
                    ),
            "Lull Atk/Def"
                => new Skill(
                    new MultiEffect(
                        new RivalEffect(new PenaltyEffect(Atk, 3)),
                        new RivalEffect(new PenaltyEffect(Def, 3)),
                        new RivalEffect(new BonusNeutralizer(Atk, Def))
                    )
                ),
            "Lull Atk/Res"
                => new Skill(
                    new MultiEffect(
                        new RivalEffect(new PenaltyEffect(Atk, 3)),
                        new RivalEffect(new PenaltyEffect(Res, 3)),
                        new RivalEffect(new BonusNeutralizer(Atk, Res))
                    )
                ),
            "Lull Spd/Def"
                => new Skill(
                    new MultiEffect(
                        new RivalEffect(new PenaltyEffect(Spd, 3)),
                        new RivalEffect(new PenaltyEffect(Def, 3)),
                        new RivalEffect(new BonusNeutralizer(Spd, Def))
                    )
                ),
            "Lull Spd/Res"
                => new Skill(
                    new MultiEffect(
                        new RivalEffect(new PenaltyEffect(Spd, 3)),
                        new RivalEffect(new PenaltyEffect(Res, 3)),
                        new RivalEffect(new BonusNeutralizer(Spd, Res))
                    )
                ),
            "Lull Def/Res"
                => new Skill(
                    new MultiEffect(
                        new RivalEffect(new PenaltyEffect(Def, 3)),
                        new RivalEffect(new PenaltyEffect(Res, 3)),
                        new RivalEffect(new BonusNeutralizer(Def, Res))
                    )
                ),
            "Fort. Def/Res"
                => new Skill(
                    new MultiEffect(
                        new BonusEffect(Def, 6),
                        new BonusEffect(Res, 6),
                        new PenaltyEffect(Atk, 2)
                        )
                    ),
            "Life and Death"
                => new Skill(
                    new MultiEffect(
                        new BonusEffect(Atk, 6),
                        new BonusEffect(Spd, 6),
                        new PenaltyEffect(Def, 5),
                        new PenaltyEffect(Res, 5)
                        )
                    ),
            "Solid Ground"
                => new Skill(
                    new MultiEffect(
                        new BonusEffect(Atk, 6),
                        new BonusEffect(Def, 6),
                        new PenaltyEffect(Res, 5)
                        )
                    ),
            "Still Water"
                => new Skill(
                    new MultiEffect(
                        new BonusEffect(Atk, 6),
                        new BonusEffect(Res, 6),
                        new PenaltyEffect(Def, 5)
                        )
                    ),
            "Dragonskin"
                => new Skill(
                    new OrCondition(
                        new RivalCondition(new IsAttacker()),
                        new NotCondition(new RivalCondition(new HealthPercentageLessThan(75)))
                        ),
                    new MultiEffect(
                        new BonusEffect(Atk, 6),
                        new BonusEffect(Spd, 6),
                        new BonusEffect(Def, 6),
                        new BonusEffect(Res, 6),
                        new RivalEffect(new BonusNeutralizer())
                        )
                    ),
            "Light and Dark"
                => new Skill(
                    new MultiEffect(
                        new RivalEffect(new PenaltyEffect(Atk, 5)),
                        new RivalEffect(new PenaltyEffect(Spd, 5)),
                        new RivalEffect(new PenaltyEffect(Def, 5)),
                        new RivalEffect(new PenaltyEffect(Res, 5)),
                        new PenaltyNeutralizer(),
                        new RivalEffect(new BonusNeutralizer())
                        )
                    ),
            _ => new Skill()
        };
        
    }
}