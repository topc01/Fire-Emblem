using Fire_Emblem.Characters;

namespace Fire_Emblem.Conditions.CharacterConditions;

public class WeaponCondition : SingleCondition
{
    private readonly Armament.ArmamentType _armamentType;
    public WeaponCondition(Armament.ArmamentType armamentType)
    {
        _armamentType = armamentType;
    }
    public override bool DoesHold(CharacterController controller)
        => controller.Character.Armament.Type == _armamentType;
}