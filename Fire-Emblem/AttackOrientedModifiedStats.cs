namespace Fire_Emblem;

public class AttackOrientedModifiedStats
{
    public readonly ModifiedStats Combat = new();
    public readonly ModifiedStats FirstAttack = new();
    public readonly ModifiedStats FollowUp = new();

    public int Atk
    {
        set => Combat.Atk += value;
    }
    public int Def
    {
        set => Combat.Def += value;
    }
    public int Res
    {
        set => Combat.Res += value;
    }
    public int Spd
    {
        set => Combat.Spd += value;
    }

    public void Neutralize(StatType statType)
    {
        Combat.Neutralize(statType);
        FirstAttack.Neutralize(statType);
        FollowUp.Neutralize(statType);
    }

    public void Reset()
    {
        Combat.Reset();
        FirstAttack.Reset();
        FollowUp.Reset();
    }
}