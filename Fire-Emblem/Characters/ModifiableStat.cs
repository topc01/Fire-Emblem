namespace Fire_Emblem.Characters;

public class ModifiableStat
{
    public string Name { get; set; }
    public int Value { get; set; }
    public int Bonus { get; set; }
    public int Penalty { get; set; }
    public bool BonusNeutralized { get; set; }
    public bool PenaltyNeutralized { get; set; }

    public int GetFinalValue()
        => Value + (BonusNeutralized ? 0 : Bonus) - (PenaltyNeutralized ? 0 : Penalty);
}