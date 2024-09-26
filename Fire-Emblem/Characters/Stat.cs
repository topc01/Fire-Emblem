namespace Fire_Emblem.Characters;

public class Stat
{
    public int Combat = 0;
    public int FirstAttack = 0;
    public int FollowUp = 0;
    public bool IsNeutralized = false;

    public int[] Values
        => new[] { Combat, FirstAttack, FollowUp };
}