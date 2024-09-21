namespace Fire_Emblem;

public class Weapon
{
    // para agregar armas solo se agregan en este enum
    private enum WeaponType
    {
        Sword,
        Axe,
        Lance,
        Bow,
        Magic
    }

    private readonly WeaponType _weaponType;
    private WeaponType GetWeaponType() => _weaponType;
    private Weapon(WeaponType weaponType)
    {
        _weaponType = weaponType;
    }
    private static readonly Dictionary<WeaponType, Weapon> Weapons = Enum
        .GetValues(typeof(WeaponType))
        .Cast<WeaponType>()
        .ToDictionary(weaponType => weaponType, weaponType => new Weapon(weaponType));

    public bool IsMagic() => _weaponType == WeaponType.Magic;
    private static readonly double[,] ResultMatrix = new double[,]
    {
        // Sword, Axe, Lance
        {  1.0,  1.2,  0.8 },  // Sword
        {  0.8,  1.0,  1.2 },  // Axe
        {  1.2,  0.8,  1.0 },  // Lance
    };
    public double GetAdvantage(Weapon opponentWeapon)
    {
        try
        {
            return ResultMatrix[(int)GetWeaponType(), (int)opponentWeapon.GetWeaponType()];
        }
        catch (IndexOutOfRangeException)
        {
            return 1.0;
        }
    }
    public static Weapon GetWeaponFromName(string weaponName) =>
        Enum.TryParse(weaponName, true, out WeaponType weaponType)
            ? Weapons[weaponType]
            : throw new ArgumentException($"El arma {weaponName} no es válida");
}