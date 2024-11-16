namespace Fire_Emblem.Characters;

public interface IUnit
{
    string Name { get; } string Weapon { get; }
    int Hp { get; } int Atk { get; }
    int Spd { get; } int Def { get; }
    int Res { get; } string[] Skills { get; }
}