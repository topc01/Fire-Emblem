using Fire_Emblem.Types;

namespace Fire_Emblem.Characters;

public class StatsNeutralizer
{
    private bool _atk = false;
    private bool _spd = false;
    private bool _def = false;
    private bool _res = false;
    
    public bool IsStatNeutralized(StatType stat)
    {
        return stat switch
        {
            StatType.Atk => _atk,
            StatType.Spd => _spd,
            StatType.Def => _def,
            StatType.Res => _res,
            _ => throw new ArgumentException("Stat unknown")
        };
    }
    
    public void NeutralizeStat(StatType stat)
    {
        switch (stat)
        {
            case StatType.Atk:
                _atk = true;
                break;
            case StatType.Spd:
                _spd = true;
                break;
            case StatType.Def:
                _def = true;
                break;
            case StatType.Res:
                _res = true;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(stat), $"Invalid stat type: {stat}");
        }
    }
}