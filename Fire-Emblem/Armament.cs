namespace Fire_Emblem;

public class Armament
{
    // para agregar armas solo se agregan en este enum
    private enum ArmamentType
    {
        Sword,
        Axe,
        Lance,
        Bow,
        Magic
    }
    public string Name;
    private readonly ArmamentType _armamentType;
    private Armament(ArmamentType armamentType)
    {
        _armamentType = armamentType;
        Name = armamentType.ToString();
    }

    private static readonly Dictionary<ArmamentType, Armament> Armaments = Enum.GetValues(typeof(ArmamentType))
        .Cast<ArmamentType>()
        .ToDictionary(armamentType => armamentType, armamentType => new Armament(armamentType));
    
    // public static Armament Sword => Armaments[ArmamentType.Sword];
    // public static Armament Axe => Armaments[ArmamentType.Axe];
    // public static Armament Lance => Armaments[ArmamentType.Lance];
    // public static Armament Bow => Armaments[ArmamentType.Bow];
    // public static Armament Magic => Armaments[ArmamentType.Magic];

    public bool IsMagic() => _armamentType == ArmamentType.Magic;

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
            return ResultMatrix[(int)_armamentType, (int)opponentArmament._armamentType];
        }
        catch (IndexOutOfRangeException)
        {
            return 1.0;
        }
    }

    public static Armament GetArmamentFromName(string armamentName) =>
        Enum.TryParse(armamentName, true, out ArmamentType armamentType)
            ? Armaments[armamentType]
            : throw new ArgumentException($"El arma {armamentName} no es válida");
}