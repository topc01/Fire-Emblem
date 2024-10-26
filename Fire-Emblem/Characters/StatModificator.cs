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

    private int _percentageDamage = 100;
    public int PercentageDamageReduction
    {
        get
        {
            int val = Convert.ToInt32(_percentageDamage * 100);
            return 100 - _percentageDamage;
        }
        set
        {
            Console.WriteLine($"Setting percentage {value}");
            int newReduction = (100 - value);
            Console.WriteLine($"Calulated percentage {newReduction}");
            this._percentageDamage = (int)(_percentageDamage * newReduction * 0.01);
            Console.WriteLine($"New percentage {_percentageDamage}");
        }
    }
    
    public int AbsoluteDamageReduction { get; set; }

    public int ReduceDamage(int damage)
    {
        double newDamage = damage * _percentageDamage * 0.01;
        newDamage = Math.Round(newDamage, 9);
        int afterPercentageDamageReduction = Convert.ToInt32(Math.Floor(newDamage));
        int afterAbsoluteDamageReduction = afterPercentageDamageReduction - AbsoluteDamageReduction;
        Console.WriteLine($"Damage: {damage} {_percentageDamage} {newDamage}");
        Console.WriteLine($"New Damage: {afterAbsoluteDamageReduction}");
        return afterAbsoluteDamageReduction;
    }
    public int Get(StatType stat)
    {
        bool bonusNeutralized = BonusNeutralizer.Get(stat);
        bool penaltyNeutralized = PenaltyNeutralizer.Get(stat);
        int bonusValue = !bonusNeutralized ? Bonus.Get(stat) : 0;
        int penaltyValue = !penaltyNeutralized ? Penalty.Get(stat) : 0;
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