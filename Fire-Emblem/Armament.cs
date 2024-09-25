namespace Fire_Emblem;

public class Armament
{
    // para agregar armas solo se agregan en este enum
    public enum ArmamentType
    {
        Sword,
        Axe,
        Lance,
        Bow,
        Magic
    }
    public string Name;
    
    public ArmamentType Type { get; init; }
    private Armament(ArmamentType armamentType)
    {
        Type = armamentType;
        Name = armamentType.ToString();
    }
    public static ArmamentType Sword => ArmamentType.Sword;
    public static ArmamentType Axe => ArmamentType.Axe;
    public static ArmamentType Lance => ArmamentType.Lance;
    public static ArmamentType Bow => ArmamentType.Bow;
    public static ArmamentType Magic => ArmamentType.Magic;

    public bool IsMagic() => Type == ArmamentType.Magic;
    private static readonly double[,] ResultMatrix = new double[,]
    {
        // Sword, Axe, Lance
        {  1.0,  1.2,  0.8 },  // Sword
        {  0.8,  1.0,  1.2 },  // Axe
        {  1.2,  0.8,  1.0 },  // Lance
    };

    public double GetAdvantage(Armament opponentArmament)
    {
        try
        {
            return ResultMatrix[(int)Type, (int)opponentArmament.Type];
        }
        catch (IndexOutOfRangeException)
        {
            return 1.0;
        }
    }

    public static Armament GetArmamentFromName(string armamentName) =>
        Enum.TryParse(armamentName, true, out ArmamentType armamentType)
            ? new Armament(armamentType)
            : throw new ArgumentException($"El arma {armamentName} no es válida");
}