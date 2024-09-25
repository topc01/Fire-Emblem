namespace Fire_Emblem;

public class AttackOrientedModifiedStats
{
    public readonly ModifiedStats FirstAttack = new();
    public readonly ModifiedStats FollowUp = new();

    public int Atk
    {
        set
        {
            FirstAttack.Atk.value = value;
            FollowUp.Atk.value = value;
        }
    }
    public int Def
    {
        set
        {
            FirstAttack.Def.value = value;
            FollowUp.Def.value = value;
        }
    }
    public int Res
    {
        set
        {
            FirstAttack.Res.value = value;
            FollowUp.Res.value = value;
        }
    }
    public int Spd
    {
        set
        {
            FirstAttack.Spd.value = value;
            FollowUp.Spd.value = value;
        }
    }

    public void Neutralize(StatType statType)
    {
        FirstAttack.Neutralize(statType);
        FollowUp.Neutralize(statType);
    }
}