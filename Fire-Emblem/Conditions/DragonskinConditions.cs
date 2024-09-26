using Fire_Emblem.Characters;

namespace Fire_Emblem.Conditions;

public class DragonskinConditions : Condition
{
    public override bool DoesHold(CharacterController character, CharacterController rival)
    {
        Console.WriteLine(rival.HP);
        Console.WriteLine(rival.BaseHp);
        bool b1 = rival.IsAttacker;
        Console.WriteLine(b1);
        int v1 = rival.HP / rival.BaseHp * 100;
        Console.WriteLine(v1);
        bool b2 = v1 >= 75;
        Console.WriteLine(b2);
        return b1 || b2;
    }
}