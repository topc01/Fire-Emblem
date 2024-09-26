namespace Fire_Emblem.Characters;

public class StatModificator(char sign)
{
    public Stat Atk = new();
    public Stat Spd = new();
    public Stat Def = new();
    public Stat Res = new();

    //public (int atk, int spd, int def, int res)[] AllValues
    public (string name, int value)[][] AllValues
        => Atk.Values
            .Zip(Spd.Values, (atk, spd) => ( atk, spd ))
            .Zip(Def.Values, (combined, def) => (combined.atk, combined.spd, def))
            .Zip(Res.Values, (combined, res) => new []
            {
                ("Atk", combined.atk), 
                ("Spd", combined.spd), 
                ("Def", combined.def), 
                ("Res", res)
            })
            .ToArray();

    private (string name, int value)[] FilterModifications((string name, int value)[] modifications)
        => modifications.Where(status => status.value != 0).ToArray();

    private string[] Format((string name, int value)[] modifications)
        => modifications.Select((status) => $"{status.name}{sign}{status.value}")
            .ToArray();

    public string[] CombatMsg => Format(FilterModifications(AllValues[0]));
    public string[] FirstAttackMsg => Format(FilterModifications(AllValues[1]));
    public string[] FollowUpMsg => Format(FilterModifications(AllValues[2]));

    public void Neutralize(StatType stat)
    {
        switch (stat)
        {
            case StatType.Atk:
                Atk.IsNeutralized = true;
                break;
            case StatType.Spd:
                Spd.IsNeutralized = true;
                break;
            case StatType.Def:
                Def.IsNeutralized = true;
                break;
            case StatType.Res:
                Res.IsNeutralized = true;
                break;
        }
    }
}