using Fire_Emblem_View;
using Fire_Emblem.Characters;
using Fire_Emblem.Skills;
using Fire_Emblem.Types;

namespace Fire_Emblem;

public class Combat
{
    private readonly View _view;
    private Player _attackingPlayer;
    private Player _defendingPlayer;

    private int _round = 1;
    
    public Combat(Player player1, Player player2, View view)
    {
        _attackingPlayer = player1;
        _defendingPlayer = player2;
        _view = view;
    }

    public bool IsThereAWinner()
        => _attackingPlayer.HasLost() || _defendingPlayer.HasLost();

    public void ExecuteBattleRound()
    {
        SetUpBattle();
        Console.WriteLine(_defendingPlayer.Controller.IsAttacker());
        Console.WriteLine(_defendingPlayer.Controller.Character.Armament.Name);
        Console.WriteLine(_defendingPlayer.Controller.Character.Name);
        PrintMessages();
        ExecuteAttackTurns();
        PrintFinalState();
        SetLastRivals();
    }

    private void SetUpBattle()
    {
        _attackingPlayer.SelectValidCharacter(_view);
        _defendingPlayer.SelectValidCharacter(_view);
        _attackingPlayer.Controller.Character.IsAttacker = true;
        _defendingPlayer.Controller.Character.IsAttacker = false;
        ApplySkills();
    }
    
    private void ApplySkills()
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

    private void PrintMessages()
    {
        PrintRoundMessage();
        PrintAdvantageMessage();
        PrintSkillsLogs();
    }
    private void PrintRoundMessage() => _view.WriteLine($"Round {_round}: {_attackingPlayer}");
    private void PrintAdvantageMessage() =>_view.WriteLine(_attackingPlayer.GetAdvantageMessage(_defendingPlayer));

    private void PrintSkillsLogs()
    {
        foreach (string log in _attackingPlayer.Controller.GetLogs())
        {
            _view.WriteLine(log);
        }
        foreach (string log in _defendingPlayer.Controller.GetLogs())
        {
            _view.WriteLine(log);
        }
    }
    private void ExecuteAttackTurns()
    {
        CharacterController attacker = _attackingPlayer.Controller;
        CharacterController defender = _defendingPlayer.Controller;
        FirstAttack(attacker, defender);
        if (!defender.IsAlive()) return;
        FirstAttack(defender,attacker);
        if (!attacker.IsAlive()) return;
        if (attacker.CanFollowUp(defender))
            FollowUp(attacker, defender);
        else if (defender.CanFollowUp(attacker))
            FollowUp(defender,attacker);
        else _view.WriteLine("Ninguna unidad puede hacer un follow up");
    }

    private void FirstAttack(CharacterController attacker, CharacterController defender)
    {
        attacker.Stage = BattleStage.FirstAttack;
        defender.Stage = BattleStage.FirstAttack;
        _view.WriteLine(attacker.Attack(defender));
    }

    private void FollowUp(CharacterController attacker, CharacterController defender)
    {
        attacker.Stage = BattleStage.FollowUp;
        defender.Stage = BattleStage.FollowUp;
        _view.WriteLine(attacker.Attack(defender));
    }
    private void PrintFinalState()
        => _view.WriteLine($"{_attackingPlayer.CharacterFinalStatus} : {_defendingPlayer.CharacterFinalStatus}");
    private void SetLastRivals()
    {
        _attackingPlayer.Controller.Character.LastRival = _defendingPlayer.Controller.Character;
        _defendingPlayer.Controller.Character.LastRival = _attackingPlayer.Controller.Character;
    }
    public void SetNextRound()
    {
        _round++;
        _attackingPlayer.Controller.Reset();
        _defendingPlayer.Controller.Reset();
        (_attackingPlayer, _defendingPlayer) = (_defendingPlayer, _attackingPlayer);
        _attackingPlayer.Controller.Character.IsAttacker = true;
        _defendingPlayer.Controller.Character.IsAttacker = false;
    }

    public Player Winner()
        => _attackingPlayer.HasLost() ? _defendingPlayer : _attackingPlayer;
}