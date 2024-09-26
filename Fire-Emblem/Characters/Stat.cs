namespace Fire_Emblem.Characters;

public class Stat
{
    private int _combat = 0;
    private int _firstAttack = 0;
    private int _followUp = 0;
    
    public int Combat {
        get => _combat;
        set => _combat = int.Abs(value);
    }
    public int FirstAttack {
        get => _firstAttack;
        set => _firstAttack = int.Abs(value);
    }
    public int FollowUp {
        get => _followUp;
        set => _followUp = int.Abs(value);
    }
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