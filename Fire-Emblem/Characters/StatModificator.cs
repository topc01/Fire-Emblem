using System.Collections;
using Fire_Emblem.Types;

namespace Fire_Emblem.Characters;

public class StatModificator(char sign)
{
    public readonly Stats Combat = new();
    public readonly Stats FirstAttack = new(" en su primer ataque");
    public readonly Stats FollowUp = new(" en su Follow-Up");
    public readonly StatsNeutralizer Neutralizer = new();

    public void Neutralize(StatType stat)
    {
        switch (stat)
        {
            case StatType.Atk:
                Neutralizer.Atk = true;
                break;
            case StatType.Spd:
                Neutralizer.Spd = true;
                break;
            case StatType.Def:
                Neutralizer.Def = true;
                break;
            case StatType.Res:
                Neutralizer.Res = true;
                break;
        }
    }

    public int Get(BattleStage stageType, StatType stat)
    {
        Stats stage = GetStage(stageType);
        return stat switch
        {
            StatType.Atk => Neutralizer.Atk ? 0 : stage.Atk,
            StatType.Spd => Neutralizer.Spd ? 0 : stage.Spd,
            StatType.Def => Neutralizer.Def ? 0 : stage.Def,
            StatType.Res => Neutralizer.Res ? 0 : stage.Res,
            _ => throw new ArgumentException()
        };
    }

    private Stats GetStage(BattleStage stage)
    {
        return stage switch
        {
            BattleStage.Combat => Combat,
            BattleStage.FirstAttack => FirstAttack,
            BattleStage.FollowUp => FollowUp,
            _ => throw new ApplicationException()
        };
    }

    public string[] GetLogs()
    {
        string[] combatLogs = Combat.GetLogs();
        string[] firsAttackLogs = FirstAttack.GetLogs();
        string[] followUpLogs = FollowUp.GetLogs();

        IEnumerable<string> concatenatedLogs = combatLogs.Concat(firsAttackLogs).Concat(followUpLogs);

        IEnumerable<string> logsWithModificatorSign = concatenatedLogs.Select((message) => message.Replace('$', sign));
        
        return logsWithModificatorSign.ToArray();
    }

    public string[] GetNeutralizedLogs()
    {
        string modificatorName = sign == '+' ? "bonus" : "penalty";
        string[] neutralizedModificatorLogs = Neutralizer.GetLogs();
        IEnumerable<string> neutralizedLogsWithModificatorName =
            neutralizedModificatorLogs.Select((message) => message.Replace("$", modificatorName));

        return neutralizedLogsWithModificatorName.ToArray();
    }

    
    
}