namespace Fire_Emblem;
using Characters;
public class CombatSummary
{
    private readonly Character _attackingCharacter;
    private readonly Character _defendingCharacter;
    private readonly BattleStep _battleStep;

    public CombatSummary(Character attackingCharacter, Character defendingCharacter, BattleStep battleStep)
    {
        _attackingCharacter = attackingCharacter;
        _defendingCharacter = defendingCharacter;
        _battleStep = battleStep;
    }

    public bool IsAttacker(CharacterController characterController)
        => _attackingCharacter.CharacterS == characterController.Character;

    public Character GetRival(CharacterController character)
        => IsAttacker(character) ? _attackingCharacter : _defendingCharacter;
}