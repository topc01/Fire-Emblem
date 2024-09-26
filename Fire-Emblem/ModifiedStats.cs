namespace Fire_Emblem;

public class ModifiedStats
{
    private (int value, bool isNeutralized) _atk = (0, false);
    private (int value, bool isNeutralized) _def = (0, false);
    private (int value, bool isNeutralized) _res = (0, false);
    private (int value, bool isNeutralized) _spd = (0, false);

    public int Atk
    {
        get => _atk.value;
        set => _atk.value += value;
    }

    public int Def
    {
        get => _def.value;
        set => _def.value += value;
    }
    public int Spd
    {
        get => _spd.value;
        set => _spd.value += value;
    }
    public int Res
    {
        get => _res.value;
        set => _res.value += value;
    }

    public void Reset()
    {
        _atk = (0, false);
        _def = (0, false);
        _spd = (0, false);
        _res = (0, false);
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