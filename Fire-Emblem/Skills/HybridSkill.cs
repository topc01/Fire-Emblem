using Fire_Emblem.Characters;
using Fire_Emblem.Conditions;
using Fire_Emblem.Conditions.LogicalConditions;
using Fire_Emblem.Effects;
using Fire_Emblem.Effects.EffectImplementations;
using Fire_Emblem.Types;

namespace Fire_Emblem.Skills;

public class HybridSkill(Condition condition, params BaseEffect[] effects) : BaseSkill
{
    /*private Condition _condition;
    private BaseEffect[] _effects;*/
    /*private BaseEffect _extraDamageEffect;
    private BaseEffect _percentageReductionEffect;
    private BaseEffect _absolutReductionEffect;
    private BaseEffect _callbackEffect;*/

    /*public HybridSkill(Condition condition, params BaseEffect[] effects)
    {
        _condition = condition;
        _effects = effects;
    }*/

    public HybridSkill(params BaseEffect[] effects) : this(new TrueCondition(), effects){}


    public override void ApplyIfDoesHold(CharacterController controller, CharacterController rival)
    {
        throw new NotImplementedException();
    }
    
    
}