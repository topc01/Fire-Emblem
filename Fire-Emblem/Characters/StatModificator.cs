namespace Fire_Emblem.Characters;

public class StatModificator(char sign)
{
    public Stat Atk = new();
    public Stat Spd = new();
    public Stat Def = new();
    public Stat Res = new();

    //public (int atk, int spd, int def, int res)[] AllValues
    public string[][] AllValues
        => Atk.Values
            .Zip(Spd.Values, (atk, spd) => ( atk, spd ))
            .Zip(Def.Values, (combined, def) => (combined.atk, combined.spd, def))
            .Zip(Res.Values, (combined, res) => new []
            {
                $"Atk{sign}{combined.atk}", 
                $"Spd{sign}{combined.spd}", 
                $"Def{sign}{combined.def}", 
                $"Res{sign}{res}"
            })
            .ToArray();

    public string[] CombatMsg => AllValues[0];
    public string[] FirstAttackMsg => AllValues[1];
    public string[] FollowUpMsg => AllValues[2];
}