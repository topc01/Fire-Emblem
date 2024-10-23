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

    public int Atk
    {
        get
        {
            bool bonusNeutralized = BonusNeutralizer.Atk;
            bool penaltyNeutralized = PenaltyNeutralizer.Atk;
            int bonusValue = !bonusNeutralized ? Bonus.Atk : 0;
            int penaltyValue = !penaltyNeutralized ? Penalty.Atk : 0;
            return bonusValue - penaltyValue;
        }
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
        get
        {
            bool bonusNeutralized = BonusNeutralizer.Spd;
            bool penaltyNeutralized = PenaltyNeutralizer.Spd;
            int bonusValue = !bonusNeutralized ? Bonus.Spd : 0;
            int penaltyValue = !penaltyNeutralized ? Penalty.Spd : 0;
            return bonusValue - penaltyValue;
        }
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
        get
        {
            bool bonusNeutralized = BonusNeutralizer.Def;
            bool penaltyNeutralized = PenaltyNeutralizer.Def;
            int bonusValue = !bonusNeutralized ? Bonus.Def : 0;
            int penaltyValue = !penaltyNeutralized ? Penalty.Def : 0;
            return bonusValue - penaltyValue;
        }
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
        get
        {
            bool bonusNeutralized = BonusNeutralizer.Res;
            bool penaltyNeutralized = PenaltyNeutralizer.Res;
            int bonusValue = !bonusNeutralized ? Bonus.Res : 0;
            int penaltyValue = !penaltyNeutralized ? Penalty.Res : 0;
            return bonusValue - penaltyValue;
        }
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