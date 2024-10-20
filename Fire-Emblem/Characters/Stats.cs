using Fire_Emblem.Types;

namespace Fire_Emblem.Characters;

public class Stats
{
    public int Atk { get; set; }
    public int Spd { get; set; }
    public int Def { get; set; }
    public int Res { get; set; }

    private readonly string _message = "";

    public Stats()
    {
        Atk = 0;
        Spd = 0;
        Def = 0;
        Res = 0;
    }

    public Stats(string message)
    {
        _message = message;
    }
    
    public string[] GetLogs()
    {
        List<string> logs = new List<string>();
        if (Atk > 0) logs.Add($"@ obtiene Atk${Atk}{_message}");
        if (Spd > 0) logs.Add($"@ obtiene Spd${Spd}{_message}");
        if (Def > 0) logs.Add($"@ obtiene Def${Def}{_message}");
        if (Res > 0) logs.Add($"@ obtiene Res${Res}{_message}");
        return logs.ToArray();
    }
}