namespace Fire_Emblem;

public class AttackOrientedModifiedStats(char sign)
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

    public string[] GetAllLogs()
        => GetFinalValues(Combat)
            .Concat(GetFinalValues(FirstAttack, " en su primer ataque"))
            .Concat(GetFinalValues(Combat, " en su Follow-Up"))
            .ToArray();
    public string[] GetCombatFinalValues()
        => GetFinalValues(Combat);
    public string[] GetFirstAttackFinalValues()
        => GetFinalValues(FirstAttack, " en su primer ataque");
    public string[] GetFollowUpFinalValues()
        => GetFinalValues(Combat, " en su Follow-Up");
    private string[] GetFinalValues(ModifiedStats stats, string message = "")
    {
        return new[]
        {
            $"obtiene Atk{sign}{stats.Atk}{message}",
            $"obtiene Spd{sign}{stats.Spd}{message}",
            $"obtiene Def{sign}{stats.Def}{message}",
            $"obtiene Res{sign}{stats.Res}{message}",
        };
    }
}