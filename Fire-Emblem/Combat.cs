using Fire_Emblem_View;
using Fire_Emblem.Characters;
using Fire_Emblem.Skills;

namespace Fire_Emblem;

public class Combat
{
    private readonly View _view;
    private Player _attackingPlayer;
    private Player _defendingPlayer;
    
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
        ApplySkillss();
        PrintSkillsLogs();
        Fight();
        PrintFinalState();
        SetLastRivals();
    }
    private void PrintRoundMessage() => _view.WriteLine($"Round {_round}: {_attackingPlayer}");
    private void PrintAdvantageMessage() =>_view.WriteLine(_attackingPlayer.AdvantageMessage(_defendingPlayer));
    private void ApplySkillss()
    {
        foreach (Skill skill in _attackingPlayer.Controller.Skills)
        {
            skill.ApplyIfDoesHold(_attackingPlayer.Controller, _defendingPlayer.Controller);
        }
        foreach (Skill skill in _defendingPlayer.Controller.Skills)
        {
            skill.ApplyIfDoesHold(_defendingPlayer.Controller, _attackingPlayer.Controller);
        }
    }

    private void PrintSkillsLogs()
    {
        foreach (string log in _attackingPlayer.Controller.Logs)
        {
            _view.WriteLine(log);
        }
        foreach (string log in _defendingPlayer.Controller.Logs)
        {
            _view.WriteLine(log);
        }
    }
    private void Fight()
    {
        CharacterController attacker = _attackingPlayer.Controller;
        CharacterController defender = _defendingPlayer.Controller;
        FirstAttack(attacker, defender);
        if (!defender.IsAlive()) return;
        FirstAttack(defender,attacker);
        if (!attacker.IsAlive()) return;
        if (attacker.CanFollowUp(defender))
            FirstAttack(attacker, defender);
        else if (defender.CanFollowUp(attacker))
            FirstAttack(defender,attacker);
        else _view.WriteLine("Ninguna unidad puede hacer un follow up");
    }
    private void FirstAttack(CharacterController attacker, CharacterController defender)
        => _view.WriteLine(attacker.FirstAttack(defender));
    private void PrintFinalState()
        => _view.WriteLine($"{_attackingPlayer.CharacterFinalStatus} : {_defendingPlayer.CharacterFinalStatus}");
    public void SetNextRound()
    {
        _round++;
        (_attackingPlayer, _defendingPlayer) = (_defendingPlayer, _attackingPlayer);
        _attackingPlayer.Controller.IsAttacker = true;
        _defendingPlayer.Controller.IsAttacker = false;
    }

    public Player Winner()
        => _attackingPlayer.HasLost() ? _defendingPlayer : _attackingPlayer;

    private void SetLastRivals()
    {
        _attackingPlayer.Controller.Character.LastRival = _defendingPlayer.Controller.Character;
        _defendingPlayer.Controller.Character.LastRival = _attackingPlayer.Controller.Character;
    }
    
}