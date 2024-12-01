using Fire_Emblem.Conditions;
using Fire_Emblem.Conditions.CharacterConditions;
using Fire_Emblem.Conditions.LogicalConditions;
using Fire_Emblem.Effects;
using Fire_Emblem.Effects.CommonEffects;
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
                        new CombatEffect(Atk, 6), new RivalEffect(new CombatEffect(Atk, 6)))),
            "Will to Win"
                => new Skill(
                    new OrCondition(
                        new HealthPercentageLessThan(50), new HealthPercentageEquals(50)),
                    new CombatEffect(Atk, 8)),
            "Single-Minded"
                => new Skill(
                    new IsLastRival(),
                    new CombatEffect(Atk, 8)),
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
                        new CombatEffect(Atk, 6), new CombatEffect(Spd, 6))),
            "Attack +6" 
                => new Skill(
                    new CombatEffect(Atk, 6)),
            "Speed +5" 
                => new Skill(
                new CombatEffect(Spd, 5)),
            "Defense +5" 
                => new Skill(
                new CombatEffect(Def, 5)),
            "Wrath"
                => new Skill(new WrathEffect()),
            "Resolve"
                => new Skill(
                    new OrCondition(
                        new HealthPercentageEquals(75), new HealthPercentageLessThan(75)),
                    new MultiEffect(
                        new CombatEffect(Def, 7), new CombatEffect(Res, 7))),
            "Resistance +5"
                => new Skill(
                    new CombatEffect(Res, 5)),
            "Atk/Def +5"
                => new Skill(
                    new MultiEffect(
                        new CombatEffect(Atk, 5), new CombatEffect(Def, 5))),
            "Atk/Res +5"
                => new Skill(
                    new MultiEffect(
                        new CombatEffect(Atk, 5), new CombatEffect(Res, 5))),
            "Spd/Res +5"
                => new Skill(
                    new MultiEffect(
                        new CombatEffect(Spd, 5), new CombatEffect(Res, 5))),
            "Deadly Blade"
                => new Skill(
                    new AndCondition(
                        new IsAttacker(), new WeaponCondition(Armament.Sword)),
                    new MultiEffect(
                        new CombatEffect(Atk, 8), new CombatEffect(Spd, 8))),
            "Death Blow"
                => new Skill(
                new IsAttacker(),
                        new CombatEffect(Atk, 8)),
            "Armored Blow"
                => new Skill(
                    new IsAttacker(),
                            new CombatEffect(Def, 8)),
            "Darting Blow"
                => new Skill(
                    new IsAttacker(),
                    new CombatEffect(Spd, 8)),
            "Warding Blow"
                => new Skill(
                    new IsAttacker(),
                    new CombatEffect(Res, 8)),
            "Swift Sparrow"
                => new Skill(
                    new IsAttacker(),
                    new MultiEffect(
                        new CombatEffect(Atk, 6), new CombatEffect(Spd, 6))),
            "Sturdy Blow"
                => new Skill(
                    new IsAttacker(),
                    new MultiEffect(
                        new CombatEffect(Atk, 6), new CombatEffect(Def, 6))),
            "Mirror Strike"
                => new Skill(
                    new IsAttacker(),
                    new MultiEffect(
                        new CombatEffect(Atk, 6), new CombatEffect(Res, 6))),
            "Steady Blow"
                => new Skill(
                    new IsAttacker(),
                    new MultiEffect(
                        new CombatEffect(Spd, 6), new CombatEffect(Def, 6))),
            "Swift Strike"
                => new Skill(
                    new IsAttacker(),
                    new MultiEffect(
                        new CombatEffect(Spd, 6), new CombatEffect(Res, 6))),
            "Bracing Blow"
                => new Skill(
                    new IsAttacker(),
                    new MultiEffect(
                        new CombatEffect(Res, 6), new CombatEffect(Def, 6))),
            "Brazen Atk/Spd"
                => new Skill(
                    new OrCondition(
                        new HealthPercentageEquals(80), new HealthPercentageLessThan(80)),
                    new MultiEffect(
                        new CombatEffect(Atk, 10), new CombatEffect(Spd, 10))),
            "Brazen Atk/Def"
                => new Skill(
                    new OrCondition(
                        new HealthPercentageEquals(80), new HealthPercentageLessThan(80)),
                    new MultiEffect(
                        new CombatEffect(Atk, 10), new CombatEffect(Def, 10))),
            "Brazen Atk/Res"
                => new Skill(
                    new OrCondition(
                        new HealthPercentageEquals(80), new HealthPercentageLessThan(80)),
                    new MultiEffect(
                        new CombatEffect(Atk, 10), new CombatEffect(Res, 10))),
            "Brazen Spd/Def"
                => new Skill(
                    new OrCondition(
                        new HealthPercentageEquals(80), new HealthPercentageLessThan(80)),
                    new MultiEffect(
                        new CombatEffect(Spd, 10), new CombatEffect(Def, 10))),
            "Brazen Spd/Res"
                => new Skill(
                    new OrCondition(
                        new HealthPercentageEquals(80), new HealthPercentageLessThan(80)),
                    new MultiEffect(
                        new CombatEffect(Spd, 10), new CombatEffect(Res, 10))),
            "Brazen Def/Res"
                => new Skill(
                    new OrCondition(
                        new HealthPercentageEquals(80), new HealthPercentageLessThan(80)),
                    new MultiEffect(
                        new CombatEffect(Def, 10), new CombatEffect(Res, 10))),
            "Fire Boost"
                => new Skill(
                    new HealthGreaterOrEqualThanRivalBy(3),
                    new CombatEffect(Atk, 6)),
            "Wind Boost"
                => new Skill(
                    new HealthGreaterOrEqualThanRivalBy(3),
                    new CombatEffect(Spd, 6)),
            "Earth Boost"
                => new Skill(
                    new HealthGreaterOrEqualThanRivalBy(3),
                    new CombatEffect(Def, 6)),
            "Water Boost"
                => new Skill(
                    new HealthGreaterOrEqualThanRivalBy(3),
                    new CombatEffect(Res, 6)),
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
                    new CombatEffect(Spd, 3)),
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
                        new CombatEffect(Spd, 12), new PenaltyEffect(Atk, 6))),
            "Lance Power"
                => new Skill(
                    new WeaponCondition(Armament.Lance),
                    new MultiEffect(
                        new CombatEffect(Atk, 10), new PenaltyEffect(Def, 10))),
            "Sword Power"
                => new Skill(
                    new WeaponCondition(Armament.Sword),
                    new MultiEffect(
                        new CombatEffect(Atk, 10), new PenaltyEffect(Def, 10))),
            "Bow Focus"
                => new Skill(
                    new WeaponCondition(Armament.Bow),
                    new MultiEffect(
                        new CombatEffect(Atk, 10), new PenaltyEffect(Res, 10))),
            "Lance Agility"
                => new Skill(
                    new WeaponCondition(Armament.Lance),
                    new MultiEffect(
                        new CombatEffect(Spd, 12), new PenaltyEffect(Atk, 6))),
            "Axe Power"
                => new Skill(
                    new WeaponCondition(Armament.Axe),
                    new MultiEffect(
                        new CombatEffect(Atk, 10), new PenaltyEffect(Def, 10))),
            "Bow Agility"
                => new Skill(
                    new WeaponCondition(Armament.Bow),
                    new MultiEffect(
                        new CombatEffect(Spd, 12), new PenaltyEffect(Atk, 6))),
            "Sword Focus"
                => new Skill(
                    new WeaponCondition(Armament.Sword),
                    new MultiEffect(
                        new CombatEffect(Atk, 10), new PenaltyEffect(Res, 10))),
            "Close Def"
                => new Skill(
                    new AndCondition(
                        new RivalCondition(new IsAttacker()),
                        new OrCondition(
                            new RivalCondition(new WeaponCondition(Armament.Sword)),
                            new RivalCondition(new WeaponCondition(Armament.Lance)), 
                            new RivalCondition (new WeaponCondition(Armament.Axe)))),
                    new MultiEffect(
                        new CombatEffect(Def, 8), new CombatEffect(Res, 8), new RivalEffect(new BonusNeutralizer()))),
            "Distant Def"
                => new Skill(
                    new AndCondition(
                        new RivalCondition(new IsAttacker()),
                            new OrCondition(
                                new RivalCondition(new WeaponCondition(Armament.Magic)),
                                new RivalCondition(new WeaponCondition(Armament.Bow)))),
                    new MultiEffect(
                        new CombatEffect(Def, 8), new CombatEffect(Res, 8), new RivalEffect(new BonusNeutralizer()))),
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
                        new CombatEffect(Def, 6),
                        new CombatEffect(Res, 6),
                        new PenaltyEffect(Atk, 2)
                        )
                    ),
            "Life and Death"
                => new Skill(
                    new MultiEffect(
                        new CombatEffect(Atk, 6),
                        new CombatEffect(Spd, 6),
                        new PenaltyEffect(Def, 5),
                        new PenaltyEffect(Res, 5)
                        )
                    ),
            "Solid Ground"
                => new Skill(
                    new MultiEffect(
                        new CombatEffect(Atk, 6),
                        new CombatEffect(Def, 6),
                        new PenaltyEffect(Res, 5)
                        )
                    ),
            "Still Water"
                => new Skill(
                    new MultiEffect(
                        new CombatEffect(Atk, 6),
                        new CombatEffect(Res, 6),
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
                        new CombatEffect(Atk, 6),
                        new CombatEffect(Spd, 6),
                        new CombatEffect(Def, 6),
                        new CombatEffect(Res, 6),
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
            "Dragon Wall"
                => new Skill(
                    new StatGreaterThanRival(Res),
                    new PercentageDamageReduceByStatDifference(Res, 4, 40)),
            "Dodge"
                => new Skill(
                    new StatGreaterThanRival(Spd),
                    new PercentageDamageReduceByStatDifference(Spd, 4, 40)),
            "Golden Lotus"
                => new Skill(
                    new NotCondition(new RivalCondition(new WeaponCondition(Armament.ArmamentType.Magic))),
                    new PercentageDamageReduce(50, BattleStage.FirstAttack)),
            "Gentility"
                => new Skill(
                    new AbsolutDamageReduce(5)),
            "Bow Guard"
                => new Skill(
                    new RivalCondition(new WeaponCondition(Armament.ArmamentType.Bow)),
                    new AbsolutDamageReduce(5)),
            "Arms Shield"
                => new Skill(
                    new HasArmamentAdvantage(),
                    new AbsolutDamageReduce(7)),
            "Axe Guard"
                => new Skill(
                    new RivalCondition(new WeaponCondition(Armament.ArmamentType.Axe)),
                    new AbsolutDamageReduce(5)),
            "Magic Guard"
                => new Skill(
                    new RivalCondition(new WeaponCondition(Armament.ArmamentType.Magic)),
                    new AbsolutDamageReduce(5)),
            "Lance Guard"
                => new Skill(
                    new RivalCondition(new WeaponCondition(Armament.ArmamentType.Lance)),
                    new AbsolutDamageReduce(5)),
            "Sympathetic"
                => new Skill(
                    new AndCondition(
                        new RivalCondition(new IsAttacker()),
                        new OrCondition(
                            new HealthPercentageEquals(50), new HealthPercentageLessThan(50))),
                    new AbsolutDamageReduce(5)),
            "Back at You"
                => new Skill(
                    new RivalCondition(new IsAttacker()),
                    new BackAtYouEffect()),
            "Lunar Brace"
                => new Skill(
                    new AndCondition(
                        new IsAttacker(),
                        new NotCondition(new WeaponCondition(Armament.ArmamentType.Magic))),
                    new LunarBraceEffect()),
            "Bravery"
                => new Skill(new ExtraDamage(5)),
            "Bushido"
                => new MultiSkill(
                    new Skill(new ExtraDamage(7)),
                    new Skill(
                        new StatGreaterThanRival(Spd),
                        new PercentageDamageReduceByStatDifference(Spd, 4, 40))),
            "Moon-Twin Wing"
                => new MultiSkill(
                    new Skill(
                            new NotCondition(new HealthPercentageLessThan(25)),
                            new MultiEffect(
                                new RivalEffect(new PenaltyEffect(Atk, 5)),
                                new RivalEffect(new PenaltyEffect(Spd, 5)))
                            ),
                        new Skill(
                            new AndCondition(
                                new StatGreaterThanRival(Spd),
                                new HealthPercentageRoundedGreaterThan(25)),
                            new PercentageDamageReduceByStatDifference(Spd, 4, 40))
                    ),
            "Blue Skies"
                => new Skill(new MultiEffect(
                    new AbsolutDamageReduce(5), new ExtraDamage(5)
                    )),
            "Aegis Shield"
                => new Skill(new MultiEffect(
                    new CombatEffect(Def, 6),
                    new CombatEffect(Res, 3),
                    new PercentageDamageReduce(50, BattleStage.FirstAttack)
                    )),
            "Remote Sparrow"=> new Skill(new IsAttacker(), new MultiEffect(new CombatEffect(Atk, 7), new CombatEffect(Spd, 7), new PercentageDamageReduce(30, BattleStage.FirstAttack))),
            "Remote Mirror" => new Skill(new IsAttacker(), new MultiEffect(new CombatEffect(Atk, 7), new CombatEffect(Res,10), new PercentageDamageReduce(30, BattleStage.FirstAttack))),
            "Remote Sturdy" => new Skill(new IsAttacker(), new MultiEffect(new CombatEffect(Atk, 7), new CombatEffect(Def,10), new PercentageDamageReduce(30, BattleStage.FirstAttack))),
            "Fierce Stance" => new Skill(new RivalCondition(new IsAttacker()), new MultiEffect(new CombatEffect(Atk,8), new PercentageDamageReduce( 10, BattleStage.FollowUp))),
            "Darting Stance" => new Skill(new RivalCondition(new IsAttacker()), new MultiEffect(new CombatEffect(Spd,8), new PercentageDamageReduce( 10, BattleStage.FollowUp))),
            "Steady Stance" => new Skill(new RivalCondition(new IsAttacker()), new MultiEffect(new CombatEffect(Def,8), new PercentageDamageReduce( 10, BattleStage.FollowUp))),
            "Warding Stance" => new Skill(new RivalCondition(new IsAttacker()), new MultiEffect(new CombatEffect(Res,8), new PercentageDamageReduce( 10, BattleStage.FollowUp))),
            "Kestrel Stance" => new Skill(new RivalCondition(new IsAttacker()), new MultiEffect(new CombatEffect(Atk,6),new CombatEffect(Spd,6), new PercentageDamageReduce( 10, BattleStage.FollowUp))),
            "Sturdy Stance" => new Skill(new RivalCondition(new IsAttacker()), new MultiEffect(new CombatEffect(Atk,6),new CombatEffect(Def,6), new PercentageDamageReduce( 10, BattleStage.FollowUp))),
            "Mirror Stance" => new Skill(new RivalCondition(new IsAttacker()), new MultiEffect(new CombatEffect(Atk,6),new CombatEffect(Res,6), new PercentageDamageReduce( 10, BattleStage.FollowUp))),
            "Steady Posture" => new Skill(new RivalCondition(new IsAttacker()), new MultiEffect(new CombatEffect(Spd,6), new CombatEffect(Def,6), new PercentageDamageReduce( 10, BattleStage.FollowUp))),
            "Swift Stance" => new Skill(new RivalCondition(new IsAttacker()), new MultiEffect(new CombatEffect(Spd,6), new CombatEffect(Res,6), new PercentageDamageReduce( 10, BattleStage.FollowUp))),
            "Bracing Stance" => new Skill(new RivalCondition(new IsAttacker()), new MultiEffect(new CombatEffect(Def,6), new CombatEffect(Res,6), new PercentageDamageReduce( 10, BattleStage.FollowUp))),
            "Poetic Justice" => new Skill(new MultiEffect(new RivalEffect(new PenaltyEffect(Spd, 4)), new ExtraDamageMultipliedByRivalStat(Atk,15))),
            "Laguz Friend" => new Skill(new MultiEffect(new PercentageDamageReduce(50), new BonusNeutralizer(Def, Res), new PenaltyFromBaseStatPercentage(Def, 50), new PenaltyFromBaseStatPercentage(Res, 50))),
            "Chivalry" => new Skill(new AndCondition(new IsAttacker(), new RivalCondition(new HealthPercentageEquals(100))),
                new MultiEffect(new ExtraDamage(2), new AbsolutDamageReduce(2))),
            "Dragon's Wrath" => new MultiSkill(
                new Skill(new PercentageDamageReduce(25, BattleStage.FirstAttack)),
                new Skill(new StatGreaterThanRival(Atk, Res), new DragonsWrathEffect())),
            "Prescience" => new MultiSkill(
                new Skill(new MultiEffect(new RivalEffect(new PenaltyEffect(Atk, 5)), new RivalEffect(new PenaltyEffect(Res, 5)))),
                new Skill(new OrCondition(
                    new IsAttacker(), new RivalCondition(new WeaponCondition(Armament.ArmamentType.Magic)), new RivalCondition(new WeaponCondition(Armament.ArmamentType.Bow))),
                    new PercentageDamageReduce(30, BattleStage.FirstAttack))),
            "Extra Chivalry" => new MultiSkill(
                new Skill(new NotCondition(new RivalCondition(new HealthPercentageLessThan(50))),
                    new MultiEffect(new RivalEffect(new PenaltyEffect(Atk, 5)), new RivalEffect(new PenaltyEffect(Spd, 5)), new RivalEffect(new PenaltyEffect(Def, 5)))),
                new Skill(new ExtraChivalry2Effect())
                ),
            "Guard Bearing" => new MultiSkill(
                new Skill(new MultiEffect(new RivalEffect(new PenaltyEffect(Spd, 4)), new RivalEffect(new PenaltyEffect(Def, 4)))),
                new Skill(new GuardBearing2Effect())
                ),
            "Divine Recreation" => new Skill(
                new NotCondition(new RivalCondition(new HealthPercentageLessThan(50))),
                new MultiEffect(
                    new RivalEffect(new PenaltyEffect(Atk, 4)),
                    new RivalEffect(new PenaltyEffect(Spd, 4)),
                    new RivalEffect(new PenaltyEffect(Def, 4)),
                    new RivalEffect(new PenaltyEffect(Res, 4)),
                    new PercentageDamageReduce(30, BattleStage.FirstAttack),
                    new DivineRecreationEffect()
                    )
                ),
            "Sol" => new Skill(new HealingEffect(25)),
            _ => new Skill()
        };
        
    }
}