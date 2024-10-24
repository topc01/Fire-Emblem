using System.Collections;
using Fire_Emblem.Types;

namespace Fire_Emblem.Characters;

public class StatModificator(string message)
{
    private const string BonusSign = "+";
    private const string PenaltySign = "-";
    public readonly Stats Bonus = new(BonusSign);
    public readonly Stats Penalty = new(PenaltySign);
    public readonly StatsNeutralizer BonusNeutralizer = new();
    public readonly StatsNeutralizer PenaltyNeutralizer = new();

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
        get => Get(StatType.Atk);
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
        get => Get(StatType.Spd);
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
        get => Get(StatType.Def);
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
        get => Get(StatType.Res);
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

    
    
}