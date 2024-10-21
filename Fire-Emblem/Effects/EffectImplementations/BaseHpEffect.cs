using Fire_Emblem.Characters;

namespace Fire_Emblem.Effects.EffectImplementations;

public class BaseHpEffect : CharacterEffect
{
    private bool _activated = false;

    public override void Apply(CharacterController controller)
    {
        if (!_activated)
            controller.Character.MaxHp += 15;
        _activated = true;
    }
}