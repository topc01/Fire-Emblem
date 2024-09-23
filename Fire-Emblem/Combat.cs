using Fire_Emblem_View;
using Fire_Emblem.Character;

namespace Fire_Emblem;

public class Combat
{
    private Player _attackingPlayer;
    private Player _defendingPlayer;
    private readonly View _view;
    
    private List<CharacterStats> _charactersInGame = new();
    
    private int _round = 1;
    
    public Combat(Player player1, Player player2, View view)
    {
        _attackingPlayer = player1;
        _defendingPlayer = player2;
        _view = view;
    }

    public bool Continues()
        => !_attackingPlayer.HasLost() && !_defendingPlayer.HasLost();

    public void Battle()
    {
        _attackingPlayer.SelectValidCharacter(_view);
        _defendingPlayer.SelectValidCharacter(_view);

        PrintRoundMessage();
        PrintAdvantageMessage();
        ApplyEffectsAndPrintMessage();
        Fight();
        PrintFinalState();
    }
    private void PrintRoundMessage() => _view.WriteLine($"Round {_round}: {_attackingPlayer}");
    private void PrintAdvantageMessage() =>_view.WriteLine(_attackingPlayer.AdvantageMessage(_defendingPlayer));
    private void ApplyEffectsAndPrintMessage()
    {
        return;
    }

    private void Fight()
    {
        CharacterController attacker = _attackingPlayer.Controller;
        CharacterController defender = _defendingPlayer.Controller;
        Attack(attacker, defender);
        if (!defender.IsAlive()) return;
        Attack(defender,attacker);
        if (!attacker.IsAlive()) return;
        if (attacker.CanFollowUp(defender))
            Attack(attacker, defender);
        else if (defender.CanFollowUp(attacker))
            Attack(defender,attacker);
        else _view.WriteLine("Ninguna unidad puede hacer un follow up");
    }
    private void Attack(CharacterController attacker, CharacterController defender)
        => _view.WriteLine(attacker.Attack(defender));
    private void PrintFinalState()
        => _view.WriteLine($"{_attackingPlayer.CharacterFinalStatus} : {_defendingPlayer.CharacterFinalStatus}");
    public void SetNextRound()
    {
        _round++;
        (_attackingPlayer, _defendingPlayer) = (_defendingPlayer, _attackingPlayer);
    }
}