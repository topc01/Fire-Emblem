using Fire_Emblem_View;
using Fire_Emblem.Characters;

namespace Fire_Emblem.Utils;

public class Logger(View view, Player attacker, Player defender)
{

    public void PrintSkillLogs(CharacterController controller)
    {
        LogStatModifications(controller);
        LogStatsNeutralizers(controller);
        LogExtraDamage(controller);
        LogPercentageDamageReduction(controller);
        LogAbsolutDamageReduction(controller);
    }
    public void LogStatModifications(CharacterController controller)
    {
        string name = controller.Character.Name;
        string firstAttackMessage = " en su primer ataque";
        string followUpMessage = " en su Follow-Up";
        
        Stats combatBonus = controller.Combat.Bonus;
        Stats firstAttackBonus = controller.FirstAttack.Bonus;
        Stats followUpBonus = controller.FollowUp.Bonus;
        
        LogStatValues(combatBonus, name);
        LogStatValues(firstAttackBonus, name, firstAttackMessage);
        LogStatValues(followUpBonus, name, followUpMessage);
        
        Stats combatPenalty = controller.Combat.Penalty;
        Stats firstAttackPenalty = controller.FirstAttack.Penalty;
        Stats followUpPenalty = controller.FollowUp.Penalty;
        
        LogStatValues(combatPenalty, name);
        LogStatValues(firstAttackPenalty, name, firstAttackMessage);
        LogStatValues(followUpPenalty, name, followUpMessage);
        
    }

    private void LogStatValues(Stats stats, string name, string message = "")
    {
        string sign = stats.Sign;
        if (stats.Atk > 0) view.WriteLine($"{name} obtiene Atk{sign}{stats.Atk}{message}");
        if (stats.Spd > 0) view.WriteLine($"{name} obtiene Spd{sign}{stats.Spd}{message}");
        if (stats.Def > 0) view.WriteLine($"{name} obtiene Def{sign}{stats.Def}{message}");
        if (stats.Res > 0) view.WriteLine($"{name} obtiene Res{sign}{stats.Res}{message}");
    }

    public void LogStatsNeutralizers(CharacterController controller)
    {
        string name = controller.Character.Name;
        string bonusName = "bonus";
        string penaltyName = "penalty";
        
        StatsNeutralizer neutralizedBonus = controller.BonusNeutralizer;
        StatsNeutralizer neutralizedPenalty = controller.PenaltyNeutralizer;

        LogNeutralizedStats(neutralizedBonus, name, bonusName);
        LogNeutralizedStats(neutralizedPenalty, name, penaltyName);
    }

    private void LogNeutralizedStats(StatsNeutralizer neutralizer, string name, string neutralizerName)
    {
        if (neutralizer.Atk) view.WriteLine($"Los {neutralizerName} de Atk de {name} fueron neutralizados");
        if (neutralizer.Spd) view.WriteLine($"Los {neutralizerName} de Spd de {name} fueron neutralizados");
        if (neutralizer.Def) view.WriteLine($"Los {neutralizerName} de Def de {name} fueron neutralizados");
        if (neutralizer.Res) view.WriteLine($"Los {neutralizerName} de Res de {name} fueron neutralizados");
    }

    public void LogExtraDamage(CharacterController controller)
    {
        string name = controller.Character.Name;
        string combatMessage = "en cada ataque";
        string firstAttackMessage = "en su primer ataque";
        string followUpMessage = "en su Follow-Up";

        int combatExtraDamage = controller.Combat.ExtraDamage;
        int firstAttackExtraDamage = controller.FirstAttack.ExtraDamage;
        int followUpExtraDamage = controller.FollowUp.ExtraDamage;

        if (combatExtraDamage > 0) view.WriteLine($"{name} realizará {combatExtraDamage} {combatMessage}");
        if (firstAttackExtraDamage > 0) view.WriteLine($"{name} realizará {firstAttackExtraDamage} {firstAttackMessage}");
        if (followUpExtraDamage > 0) view.WriteLine($"{name} realizará {followUpExtraDamage} {followUpMessage}");
    }
    
    public void LogPercentageDamageReduction(CharacterController controller)
    {
        string name = controller.Character.Name;
        string combatMessage = "de los ataques";
        string firstAttackMessage = "del primer ataque";
        string followUpMessage = "del Follow-Up";

        int combatPercentageDamageReduce = controller.Combat.PercentageDamageReduction;
        int firstAttackPercentageDamageReduce = controller.FirstAttack.PercentageDamageReduction;
        int followUpPercentageDamageReduce = controller.FollowUp.PercentageDamageReduction;

        if (combatPercentageDamageReduce > 0) view.WriteLine($"{name} reducirá el daño {combatMessage} del rival en un {combatPercentageDamageReduce}%");
        if (firstAttackPercentageDamageReduce > 0) view.WriteLine($"{name} reducirá el daño {firstAttackMessage} del rival en un {firstAttackPercentageDamageReduce}%");
        if (followUpPercentageDamageReduce > 0) view.WriteLine($"{name} reducirá el daño {followUpMessage} del rival en un {followUpPercentageDamageReduce}%");
    }

    public void LogAbsolutDamageReduction(CharacterController controller)
    {
        string name = controller.Character.Name;
        int absolutDamageReduction = controller.Combat.AbsoluteDamageReduction;
        if (absolutDamageReduction > 0) view.WriteLine($"{name} recibirá -{absolutDamageReduction} daño en cada ataque");
    }
    
    
    
}