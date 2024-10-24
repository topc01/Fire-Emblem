using Fire_Emblem.Types;

namespace Fire_Emblem.Characters;

public class Stats
{
    public int Atk { get; set; }
    public int Spd { get; set; }
    public int Def { get; set; }
    public int Res { get; set; }

    private readonly string _sign = "";

    public Stats()
    {
        Atk = 0;
        Spd = 0;
        Def = 0;
        Res = 0;
    }

    public Stats(string sign)
    {
        _sign = sign;
        Atk = 0;
        Spd = 0;
        Def = 0;
        Res = 0;
    }

    public int Get(StatType stat)
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
    
    public void Set(StatType stat, int value)
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
        if (Atk > 0) logs.Add($"@ obtiene Atk{_sign}{Atk}#");
        if (Spd > 0) logs.Add($"@ obtiene Spd{_sign}{Spd}#");
        if (Def > 0) logs.Add($"@ obtiene Def{_sign}{Def}#");
        if (Res > 0) logs.Add($"@ obtiene Res{_sign}{Res}#");
        return logs.ToArray();
    }
}