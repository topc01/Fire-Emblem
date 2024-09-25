namespace Fire_Emblem;

public class ModifiedStats
{
    private (int value, bool isNeutralized) _atk;
    private (int value, bool isNeutralized) _def;
    private (int value, bool isNeutralized) _res;
    private (int value, bool isNeutralized) _spd;

    public int Atk
    {
        get => _atk.value;
        set => _atk.value = value;
    }

    public int Def
    {
        get => _def.value;
        set => _def.value = value;
    }
    public int Spd
    {
        get => _spd.value;
        set => _spd.value = value;
    }
    public int Res
    {
        get => _res.value;
        set => _res.value = value;
    }

    private (int, bool) GetStat(StatType statType)
    {
        return statType switch
        {
            StatType.Atk => _atk,
            StatType.Def => _def,
            StatType.Res => _res,
            StatType.Spd => _spd,
            _ => throw new ApplicationException()
        };
    }
    public void Set(StatType statType, int value)
    {
        switch (statType)
        {
            case StatType.Atk:
                _atk.value = value;
                break;
            case StatType.Def:
                _def.value = value;
                break;
            case StatType.Res:
                _res.value = value;
                break;
            case StatType.Spd:
                _spd.value = value;
                break;
        }
    }
    public void Neutralize(StatType statType)
    {
        switch (statType)
        {
            case StatType.Atk:
                _atk.isNeutralized = true;
                break;
            case StatType.Def:
                _def.isNeutralized = true;
                break;
            case StatType.Res:
                _res.isNeutralized = true;
                break;
            case StatType.Spd:
                _spd.isNeutralized = true;
                break;
        }
    }
}