namespace Fire_Emblem;

public class ModifiedStats
{
    public (int value, bool isNeutralized) Atk;
    public (int value, bool isNeutralized) Def;
    public (int value, bool isNeutralized) Res;
    public (int value, bool isNeutralized) Spd;

    private (int, bool) GetStat(StatType statType)
    {
        return statType switch
        {
            StatType.Atk => Atk,
            StatType.Def => Def,
            StatType.Res => Res,
            StatType.Spd => Spd,
            _ => throw new ApplicationException()
        };
    }
    public void Set(StatType statType, int value)
    {
        switch (statType)
        {
            case StatType.Atk:
                Atk.value = value;
                break;
            case StatType.Def:
                Def.value = value;
                break;
            case StatType.Res:
                Res.value = value;
                break;
            case StatType.Spd:
                Spd.value = value;
                break;
        }
    }
    public void Neutralize(StatType statType)
    {
        switch (statType)
        {
            case StatType.Atk:
                Atk.isNeutralized = true;
                break;
            case StatType.Def:
                Def.isNeutralized = true;
                break;
            case StatType.Res:
                Res.isNeutralized = true;
                break;
            case StatType.Spd:
                Spd.isNeutralized = true;
                break;
        }
    }
}