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
    private readonly Logger _logger;
    public Game(View view, string teamsFolder)
    {
        _view = view;
        _logger = new Logger(_view);
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
        
        while (!combat.IsThereAWinner())
        {
            combat.ExecuteBattleRound();
            combat.SetNextRound();
        }

        Player winner = combat.Winner();
        _view.WriteLine($"Player {winner.PlayerNumber} ganó");
    }
    private CharacterStats FindCharacterStatsByName(string characterName)
        => Array.Find(_allCharacters, character => character.Name == characterName) ?? 
           throw new Exception("No se encontro el personaje");
}