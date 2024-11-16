using Fire_Emblem.Types;

namespace Fire_Emblem.Characters;

public class StatsNeutralizer
{
    public bool Atk {get; private set; } = false;
    public bool Spd {get; private set; } = false;
    public bool Def {get; private set; } = false;
    public bool Res {get; private set; } = false;
    
    public bool IsStatNeutralized(StatType stat)
    {
        return stat switch
        {
            StatType.Atk => Atk,
            StatType.Spd => Spd,
            StatType.Def => Def,
            StatType.Res => Res,
            _ => throw new ArgumentException("Stat unknown")
        };
    }
    
    public void NeutralizeStat(StatType stat)
    {
        switch (stat)
        {
            case StatType.Atk:
                Atk = true;
                break;
            case StatType.Spd:
                Spd = true;
                break;
            case StatType.Def:
                Def = true;
                break;
            case StatType.Res:
                Res = true;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(stat), $"Invalid stat type: {stat}");
        }
    }
}