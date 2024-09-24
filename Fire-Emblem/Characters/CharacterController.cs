using Fire_Emblem.Skills;

namespace Fire_Emblem.Characters;

public class CharacterController
{
    private CharacterStats? _character;
    private List<Skill>? _skills;
    public CharacterStats Character
    {
        set => _character = value;
        get => _character ?? throw new InvalidOperationException("Character is not initialized.");
    }
    public void SetCharacter(Character character)
    {
        Character = character.CharacterS;
        _skills = character.Skills;
    }
    public string Fight(CharacterController defender)
    {
        int damage = DamageAgainst(defender);
        defender.ReceiveDamage(damage);
        return $"{Name} ataca a {defender.Name} con {damage} de daño";
    }
    private int DamageAgainst(CharacterController opponent)
    {
        int atk = Character.Atk;
        Armament armament = Character.Armament;
        double advantage = armament.GetAdvantage(opponent.Character.Armament);
        double rivalDefense = armament.IsMagic() ? opponent.Character.Res : opponent.Character.Def;
        return int.Max((int)(atk * advantage - rivalDefense), 0);
    }
    private string WeaponName => Character.Weapon;
    public string Name => Character.Name;
    public bool IsAlive() => Character.Health > 0;
    public bool CanFollowUp(CharacterController opponent) => Character.Spd - opponent.Character.Spd >= 5;
    private void ReceiveDamage(int damage) => Character.Health -= damage;
    public string CheckAdvantages(CharacterController opponent)
    {
        Armament armament = Character.Armament;
        double advantage = armament.GetAdvantage(opponent.Character.Armament);
        return advantage switch
        {
            1.0 => "Ninguna unidad tiene ventaja con respecto a la otra",
            > 1.0 => $"{Name} ({WeaponName}) tiene ventaja con respecto a {opponent.Name} ({opponent.WeaponName})",
            < 1.0 => $"{opponent.Name} ({opponent.WeaponName}) tiene ventaja con respecto a {Name} ({WeaponName})",
            _ => throw new Exception($"Unknown advantage for {WeaponName} and {opponent.WeaponName}")
        };
    }
    public override string ToString() => $"{Name} ({Character.Health})";
}