using Fire_Emblem_View;
using Fire_Emblem.Characters;

namespace Fire_Emblem.Utils;

public class Logger(View view)
{

    public void LogBonuses(CharacterController controller)
    {
        Stats combatBonus = controller.Combat.Bonus;
        Stats firstAttackBonus = controller.FirstAttack.Bonus;
        Stats followUpBonus = controller.FollowUp.Bonus;
        string[] logs = GetLogsAndConcat(combatBonus, firstAttackBonus, followUpBonus);
        string[] logsWithName = ReplaceName(logs, controller.Character.Name);
        foreach (string log in logsWithName)
        {
            WriteLine(log);
        }

    }
    
    public void LogPenalties(CharacterController controller)
    {
        Stats combatPenalty = controller.Combat.Penalty;
        Stats firstAttackPenalty = controller.FirstAttack.Penalty;
        Stats followUpPenalty = controller.FollowUp.Penalty;
        string[] logs = GetLogsAndConcat(combatPenalty, firstAttackPenalty, followUpPenalty);
        string[] logsWithName = ReplaceName(logs, controller.Character.Name);
        foreach (string log in logsWithName)
        {
            WriteLine(log);
        }

    }

    private string[] GetLogsAndConcat(params Stats[] modificators)
    {
        List<string> logs = new List<string>();
        foreach (Stats modificator in modificators)
        {
            string[] statLogs = modificator.GetLogs();
            logs.AddRange(modificator.GetLogs());
        }

        return logs.ToArray();
    }
    private void WriteLine(string message)
        => view.WriteLine(message);
    
    public static string[] AddManyLogs(params string[][] logsList)
    {
        List<string> list = new List<string>();
        foreach (string[] logs in logsList)
        {
            list.AddRange(logs);
        }

        return list.ToArray();
    }
    
    public string[] ReplaceName(string[] list, string name)
        => list.Select((message) => message.Replace("@", name)).ToArray();
    
    public string[] ReplaceMessage(string[] list, string text)
        => list.Select((message) => message.Replace("#", text)).ToArray();
}