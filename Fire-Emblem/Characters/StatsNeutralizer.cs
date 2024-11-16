using Fire_Emblem.Types;

namespace Fire_Emblem.Characters;

public class StatsNeutralizer
{
    private bool _atk = false;
    private bool _spd = false;
    private bool _def = false;
    private bool _res = false;
    
    public bool Get(StatType stat)
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
    
    public void Set(StatType stat, bool value)
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

    public string[] GetLogs()
    {
        List<string> logs = new List<string>();
        if (_atk) logs.Add($"Los $ de Atk de @ fueron neutralizados");
        if (_spd) logs.Add($"Los $ de Spd de @ fueron neutralizados");
        if (_def) logs.Add($"Los $ de Def de @ fueron neutralizados");
        if (_res) logs.Add($"Los $ de Res de @ fueron neutralizados");
        return logs.ToArray();
    }
    
    
}