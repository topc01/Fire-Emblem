namespace Fire_Emblem;

public class AttackOrientedModifiedStats
{
    public readonly ModifiedStats FirstAttack = new();
    public readonly ModifiedStats FollowUp = new();

    public int Atk
    {
        set
        {
            FirstAttack.Atk += value;
            FollowUp.Atk += value;
        }
    }
    public int Def
    {
        set
        {
            FirstAttack.Def += value;
            FollowUp.Def += value;
        }
    }
    public int Res
    {
        set
        {
            FirstAttack.Res += value;
            FollowUp.Res += value;
        }
    }
    public int Spd
    {
        set
        {
            FirstAttack.Spd += value;
            FollowUp.Spd += value;
        }
    }

    public void Neutralize(StatType statType)
    {
        FirstAttack.Neutralize(statType);
        FollowUp.Neutralize(statType);
    }

    public void Reset()
    {
        FirstAttack.Reset();
        FollowUp.Reset();
    }
}