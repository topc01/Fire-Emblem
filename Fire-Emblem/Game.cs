using System.Text.Json;
using Fire_Emblem_View;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using Fire_Emblem.Character;

namespace Fire_Emblem;
public class Game
{
    private readonly View _view;
    private readonly string[] _teamFiles;
    
    private const string CharactersFile = "characters.json";
    private readonly CharacterStats[] _allCharacters;
    
    private const string SkillsFile = "skills.json";
    private readonly Skill[] _allSkills;
    
    private readonly Player _player1;
    private readonly Player _player2;

    private readonly Combat _combat;
    private readonly DataParser _dataParser = new();
    private readonly TeamReader _teamReader;
    public Game(View view, string teamsFolder)
    {
        _view = view;
        _teamFiles = _dataParser.RetrieveTeamFilesFromFolder(teamsFolder);
        _allCharacters = _dataParser.SetUpCharacters(CharactersFile);
        _allSkills = _dataParser.SetUpSkills(SkillsFile);
        _player1 = new Player(1);
        _player2 = new Player(2);
        _combat = new Combat(_player1, _player2, _view);
        _teamReader = new TeamReader(_teamFiles, _view);
    }

    public void Play()
    {
        _teamReader.ChooseTeamFile();
        _teamReader.SetCharacterFinder(FindCharacterStatsByName);
        _teamReader.SetSkillFinder(FindSkillByName);
        _teamReader.SetUpTeams(_player1, _player2);
        if (!(_player1.IsValidTeam() && _player2.IsValidTeam()))
        {
            _view.WriteLine("Archivo de equipos no válido");
            return;
        }
        
        while (_combat.Continues())
        {
            _combat.Battle();
            _combat.SetNextRound();
        }

        Player winner = _player1.HasLost() ? _player2 : _player1;
        _view.WriteLine($"Player {winner.PlayerNumber} ganó");
    }
    private CharacterStats FindCharacterStatsByName(string characterName)
        => Array.Find(_allCharacters, character => character.Name == characterName) ?? 
           throw new Exception("No se encontro el personaje");
    private Skill FindSkillByName(string skillName) 
        => Array.Find(_allSkills, skill => skill.Name == skillName) ?? 
           throw new Exception("No se encontro el skill");
    
}