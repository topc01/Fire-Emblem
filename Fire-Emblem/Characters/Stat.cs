namespace Fire_Emblem.Characters;

public class Stat
{
    public int Combat = 0;
    public int FirstAttack = 0;
    public int FollowUp = 0;
    public bool IsNeutralized = false;

    public int[] Values
        => new[] { Combat, FirstAttack, FollowUp };

    public int Get(BattleStage stage)
        => IsNeutralized
            ? 0
            : Combat + BattleStageValue(stage);

    private int BattleStageValue(BattleStage stage)
    {
        return stage switch
        {
            BattleStage.FirstAttack => FirstAttack,
            BattleStage.FollowUp => FollowUp,
            _ => 0,
        };
    }
}