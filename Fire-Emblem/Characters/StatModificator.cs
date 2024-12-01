using System.Collections;
using Fire_Emblem.Types;

namespace Fire_Emblem.Characters;

public class StatModificator()
{
    private const string BonusSign = "+";
    private const string PenaltySign = "-";
    public readonly Stats Bonus = new(BonusSign);
    public readonly Stats Penalty = new(PenaltySign);
    public readonly StatsNeutralizer BonusNeutralizer = new();
    public readonly StatsNeutralizer PenaltyNeutralizer = new();
    public int ExtraDamage { get; set; }

    public int PercentageDamage = 100;
    public int PercentageDamageReduction
    {
        get
        {
            int val = Convert.ToInt32(PercentageDamage * 100);
            return 100 - PercentageDamage;
        }
        set
        {
            int newReduction = (100 - value);
            PercentageDamage = (int)(PercentageDamage * newReduction * 0.01);
        }
    }
    
    public int AbsoluteDamageReduction { get; set; }
    
    public int HealingFactor { get; set; }
    
    public int DamageBefore { get; set; }
    
    public int DamageAfter { get; set; }

    public int GuaranteesNumber { get; set; }
    public bool GuaranteeNegated { get; set; } = false;
    public bool IsGuaranteed() => GuaranteesNumber > 0 && !GuaranteeNegated;

    public int NegationsNumber { get; set; }
    public bool NegationNegated { get; set; } = false;
    public bool IsNegated() => NegationsNumber > 0 && !NegationNegated;

    public int ApplyPercentageDamageReduction(int damage)
    {
        double newDamage = damage * PercentageDamage * 0.01;
        newDamage = Math.Round(newDamage, 9);
        int afterPercentageDamageReduction = Convert.ToInt32(Math.Floor(newDamage));
        Console.WriteLine($"  > %red: {damage} -> {newDamage} -> {afterPercentageDamageReduction}");
        return afterPercentageDamageReduction;
    }

    public int ApplyAbsolutDamageReduction(int damage)
        => damage - AbsoluteDamageReduction;
    
    public int GetStatValue(StatType stat)
    {
        bool bonusNeutralized = BonusNeutralizer.IsStatNeutralized(stat);
        bool penaltyNeutralized = PenaltyNeutralizer.IsStatNeutralized(stat);
        int bonusValue = bonusNeutralized ? 0 : Bonus.GetStat(stat);
        int penaltyValue = penaltyNeutralized ? 0 : Penalty.GetStat(stat);
        return bonusValue - penaltyValue;
    }

    public int Atk
    {
        set
        {
            if (value < 0)
            {
                Penalty.Atk += int.Abs(value);
                return;
            }

            Bonus.Atk += value;
        }
    }
    public int Spd
    {
        set
        {
            if (value < 0)
            {
                Penalty.Spd += int.Abs(value);
                return;
            }

            Bonus.Spd += value;
        }
    }
    public int Def
    {
        set
        {
            if (value < 0)
            {
                Penalty.Def += int.Abs(value);
                return;
            }

            Bonus.Def += value;
        }
    }
    public int Res
    {
        set
        {
            if (value < 0)
            {
                Penalty.Res += int.Abs(value);
                return;
            }

            Bonus.Res += value;
        }
    }

    public string GetExtraDamageLog()
        => ExtraDamage > 0 ? $"@ realizará +{ExtraDamage} daño extra#" : "";
    public string GetPercentageReducedDamageLog()
        => PercentageDamageReduction > 0 ? $"@ reducirá el daño de# del rival en un {PercentageDamageReduction}%" : "";
    public string GetAbsolutReducedDamageLog()
            => AbsoluteDamageReduction > 0 ? $"@ recibirá -{AbsoluteDamageReduction} daño en cada ataque" : "";



}