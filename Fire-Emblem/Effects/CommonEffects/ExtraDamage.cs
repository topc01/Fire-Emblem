using Fire_Emblem.Characters;
using Fire_Emblem.Types;

namespace Fire_Emblem.Effects.CommonEffects;

public class ExtraDamage : BaseEffect
{
    private readonly BattleStage _stage;
    private readonly int _value;
    
    public ExtraDamage(int value, BattleStage stage = BattleStage.Combat, EffectType type = EffectType.ExtraDamage)
    {
        Type = type;
        _stage = stage;
        _value = value;
    }
    public override void Apply(CharacterController controller, CharacterController rival)
    {
        controller.LogStatus();
        rival.LogStatus();
        int damage = CalculateDamage(controller, rival);
        if (_stage == BattleStage.Combat)
            controller.Combat.ExtraDamage += damage;
        else if (_stage == BattleStage.FirstAttack)
            controller.FirstAttack.ExtraDamage += damage;
        else
            controller.FollowUp.ExtraDamage += damage;
        controller.LogStatus();
        rival.LogStatus();
    }

    protected virtual int CalculateDamage(CharacterController _1, CharacterController _2)
        => _value;
}