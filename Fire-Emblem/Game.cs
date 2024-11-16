using Fire_Emblem_View;
using Fire_Emblem.Characters;
using Fire_Emblem.Skills;
using Fire_Emblem.Utils;

namespace Fire_Emblem;
public class Game
{
    private readonly View _view;
    
    private const string CharactersFile = "characters.json";
    private readonly CharacterStats[] _allCharacters;
    
    private readonly DataParser _dataParser = new();
    private readonly TeamReader _teamReader;
    public Game(View view, string teamsFolder)
    {
        _view = view;
        string[] teamFiles = _dataParser.RetrieveTeamFilesFromFolder(teamsFolder);
        _allCharacters = _dataParser.SetUpCharacters(CharactersFile);
        _teamReader = new TeamReader(teamFiles, _view);
    }

    public void Play()
    {
        _teamReader.ChooseTeamFile();
        _teamReader.SetCharacterFinder(FindCharacterStatsByName);
        _teamReader.SetUpTeams();
        if (!(_teamReader.AreValidTeams()))
        {
            _view.WriteLine("Archivo de equipos no válido");
            return;
        }

        (Player player1, Player player2) = _teamReader.GetTeams();
        
        Combat combat = new(player1, player2, _view);
        (Player attacker, Player defender) = combat.GetPlayers();
        Logger logger = new(_view, attacker, defender);
        
        while (!combat.IsThereAWinner())
        {
            /*
            combat.ExecuteBattleRound();
            */
            combat.SelectCharacters();
            combat.ApplySkills();
            combat.PrintRoundMessage();
            combat.PrintAdvantageMessage();

            CharacterController attackingCharacter = combat.GetAttackingCharacter();
            CharacterController defendingCharacter = combat.GetDefendingCharacter();
            
            logger.PrintSkillLogs(attackingCharacter);
            logger.PrintSkillLogs(defendingCharacter);
            
            combat.ExecuteAttackTurns();
            
            combat.PrintFinalState();
            combat.SetLastRivals();
            combat.SetNextRound();
        }

        Player winner = combat.Winner();
        _view.WriteLine($"Player {winner.PlayerNumber} ganó");
    }
    private CharacterStats FindCharacterStatsByName(string characterName)
        => Array.Find(_allCharacters, character => character.Name == characterName) ?? 
           throw new Exception("No se encontro el personaje");
}