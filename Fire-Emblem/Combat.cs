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

    public CharacterController GetAttackingCharacter() => _attackingPlayer.Controller;
    public CharacterController GetDefendingCharacter() => _defendingPlayer.Controller;

    public (Player, Player) GetPlayers() =>
        (_attackingPlayer, _defendingPlayer);

    private int _round = 1;
    
    public Combat(Player player1, Player player2, View view)
    {
        _attackingPlayer = player1;
        _defendingPlayer = player2;
        _view = view;
    }

    public bool IsThereAWinner()
        => _attackingPlayer.HasLost() || _defendingPlayer.HasLost();

    /*public void ExecuteBattleRound()
    {
        SetUpBattle();
        PrintMessages();
        ExecuteAttackTurns();
        PrintFinalState();
        SetLastRivals();
    }*/

    public void SelectCharacters()
    {
        _attackingPlayer.SelectValidCharacter(_view);
        _defendingPlayer.SelectValidCharacter(_view);
        _attackingPlayer.Controller.Character.IsAttacker = true;
        _defendingPlayer.Controller.Character.IsAttacker = false;
        // ApplySkills();
    }
    
    public void ApplySkills()
    {
        _attackingPlayer.ApplySkills(_defendingPlayer.Controller, EffectType.Stat);
        _defendingPlayer.ApplySkills(_attackingPlayer.Controller, EffectType.Stat);
        _attackingPlayer.ApplySkills(_defendingPlayer.Controller, EffectType.ExtraDamage);
        _defendingPlayer.ApplySkills(_attackingPlayer.Controller, EffectType.ExtraDamage);
        _attackingPlayer.ApplySkills(_defendingPlayer.Controller, EffectType.PercentageReduction);
        _defendingPlayer.ApplySkills(_attackingPlayer.Controller, EffectType.PercentageReduction);
        _attackingPlayer.ApplySkills(_defendingPlayer.Controller, EffectType.AbsolutReduction);
        _defendingPlayer.ApplySkills(_attackingPlayer.Controller, EffectType.AbsolutReduction);
        _attackingPlayer.ApplySkills(_defendingPlayer.Controller, EffectType.Callback);
        _defendingPlayer.ApplySkills(_attackingPlayer.Controller, EffectType.Callback);
        
    }
    
    public void PrintRoundMessage() => _view.WriteLine($"Round {_round}: {_attackingPlayer}");
    public void PrintAdvantageMessage() =>_view.WriteLine(_attackingPlayer.GetAdvantageMessage(_defendingPlayer));
    
    public void ExecuteAttackTurns()
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
    public void PrintFinalState()
        => _view.WriteLine($"{_attackingPlayer.CharacterFinalStatus} : {_defendingPlayer.CharacterFinalStatus}");
    public void SetLastRivals()
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
    }

    public Player Winner()
        => _attackingPlayer.HasLost() ? _defendingPlayer : _attackingPlayer;
}