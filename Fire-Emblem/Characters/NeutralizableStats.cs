using Fire_Emblem.Types;

namespace Fire_Emblem.Characters;

public class StatsNeutralizer
{
    public bool Atk = false;
    public bool Spd = false;
    public bool Def = false;
    public bool Res = false;
    
    public bool Get(StatType stat)
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
    
    public void Set(StatType stat, bool value)
    {
        switch (stat)
        {
            case StatType.Atk:
                Atk = value;
                break;
            case StatType.Spd:
                Spd = value;
                break;
            case StatType.Def:
                Def = value;
                break;
            case StatType.Res:
                Res = value;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(stat), $"Invalid stat type: {stat}");
        }
    }

    public string[] GetLogs()
    {
        List<string> logs = new List<string>();
        if (Atk) logs.Add($"Los $ de Atk de @ fueron neutralizados");
        if (Spd) logs.Add($"Los $ de Spd de @ fueron neutralizados");
        if (Def) logs.Add($"Los $ de Def de @ fueron neutralizados");
        if (Res) logs.Add($"Los $ de Res de @ fueron neutralizados");
        return logs.ToArray();
    }
    
    
}