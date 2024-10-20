using Fire_Emblem.Types;

namespace Fire_Emblem.Characters;

public class StatsNeutralizer
{
    public bool Atk { get; set; }
    public bool Spd { get; set; }
    public bool Def { get; set; }
    public bool Res { get; set; }

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