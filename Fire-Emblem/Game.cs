using System.Text.Json;
using Fire_Emblem_View;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace Fire_Emblem;
public class Game
{
    private readonly View _view;
    private readonly string _teamsFolder;
    private string[] _teamFiles;
    private const string CharactersFile = "characters.json";
    private CharacterStats[] _characters;
    private const string SkillsFile = "skills.json";
    private Skill[] _skills;
    private readonly Player _player1;
    private readonly Player _player2;
    private Player attackingPlayer;
    private Player defendingPlayer;
    private int _round = 1;
    private readonly JsonSerializerOptions _options = new()
    {
        NumberHandling = JsonNumberHandling.AllowReadingFromString | 
                         JsonNumberHandling.WriteAsString,
        IncludeFields = true
    };
    
    public Game(View view, string teamsFolder)
    {
        _view = view;
        _teamsFolder = teamsFolder;
        SetUpTeamsFolder();
        SetUpCharacters();
        SetUpSkills();
        _player1 = new Player(1);
        _player2 = new Player(2);
        attackingPlayer = _player1;
        defendingPlayer = _player2;
    }

    public void Play()
    {
        ChooseTeamFile();
        if (!(_player1.IsValidTeam() && _player2.IsValidTeam()))
        {
            _view.WriteLine("Archivo de equipos no válido");
            return;
        }

        while (!_player1.HasLost() && !_player2.HasLost())  
            PlayTurn();

        Player winner = _player1.HasLost() ? _player2 : _player1;
        _view.WriteLine($"Player {winner.PlayerNumber} ganó");
    }

    private void PlayTurn()
    {
        //Team currentPlayerTeam = _isPlayer1Turn ? _player1Team : _player2Team;
        //Team opponentTeam = _isPlayer1Turn ? _player2Team : _player1Team;
        
        attackingPlayer.SelectLiveCharacter(_view);
        defendingPlayer.SelectLiveCharacter(_view);

        PrintRoundMessage();
        PrintAdvantageMessage();
        StartBattle();
        PrintFinalState();
        NextRound();
    }
    private void PrintRoundMessage() => _view.WriteLine($"Round {_round}: {attackingPlayer}");
    private void PrintAdvantageMessage() =>_view.WriteLine(attackingPlayer.AdvantageMessage(defendingPlayer));
    private void PrintFinalState()
        => _view.WriteLine($"{attackingPlayer.CharacterFinalStatus} : {defendingPlayer.CharacterFinalStatus}");

    private void NextRound()
    {
        _round++;
        (attackingPlayer, defendingPlayer) = (defendingPlayer, attackingPlayer);
    }

    private void StartBattle()
    {
        CharacterController attacker = attackingPlayer.Controller;
        CharacterController defender = defendingPlayer.Controller;
        _view.WriteLine(attacker.Attack(defender));
        if (!defender.IsAlive()) return;
        _view.WriteLine(defender.Attack(attacker));
        if (!attacker.IsAlive()) return;
        if (attacker.CanFollowUp(defender))
            _view.WriteLine(attacker.Attack(defender));
        else if (defender.CanFollowUp(attacker))
            _view.WriteLine(defender.Attack(attacker));
        else _view.WriteLine("Ninguna unidad puede hacer un follow up");
    }
    private void ChooseTeamFile()
    {
        _view.WriteLine("Elige un archivo para cargar los equipos");
        ShowAvailableTeams();
        int choice;
        while (!int.TryParse(_view.ReadLine(), out choice) 
               || choice < 0 
               || choice >= _teamFiles.Length) ;
        SetUpTeamFile(_teamFiles[choice]);
    }
    private void SetUpTeamFile(string teamFile)
    {
        if (!File.Exists(teamFile)) throw new Exception("No existe el archivo de equipo");
        string[] lines = File.ReadAllLines(teamFile);
        
        Player currentPlayer = _player1;
        foreach (var line in lines)
        {
            if (line == "Player 1 Team") currentPlayer = _player1;
            else if (line == "Player 2 Team") currentPlayer = _player2;
            else
            {
                Character? character = ParseLine(line);
                if (character != null)
                    currentPlayer.AddCharacter(character);
            }
        }
    }
    private Character? ParseLine(string line)
    {
        string pattern = @"^(\w+)(?:\s*\(([^)]+)\))?$";
        Match match = Regex.Match(line, pattern);

        if (!(match.Success)) return null;
            
        string characterName = match.Groups[1].Value;
        CharacterStats characterStats = FindCharacterStatsByName(characterName).New();
        Character character = new Character(characterStats);
        if (match.Groups[2].Success)
        {
            string[] skillNames = match.Groups[2].Value.Split(',');
            Skill[] skills = skillNames.Select(FindSkillByName).ToArray();
            character.AddSkills(skills);
        }

        return character;
    }
    private CharacterStats FindCharacterStatsByName(string characterName)
        => Array.Find(_characters, character => character.Name == characterName) ?? 
            throw new Exception("No se encontro el personaje");
    private Skill FindSkillByName(string skillName) 
        => Array.Find(_skills, skill => skill.Name == skillName) ?? 
           throw new Exception("No se encontro el skill");
    private void SetUpTeamsFolder()
    {
        if (!Directory.Exists(_teamsFolder)) throw new Exception("No existe la carpeta de equipos");
        _teamFiles = Directory.GetFiles(_teamsFolder, "*.txt").OrderBy(f => f).ToArray();
    }
    private void SetUpCharacters()
    {
        if (!File.Exists(CharactersFile)) throw new Exception("No existe el archivo de personajes");
        string charactersJson = File.ReadAllText(CharactersFile);
        _characters = JsonSerializer.Deserialize<CharacterStats[]>(charactersJson, _options)
                                 ?? throw new Exception("No fue posible obtener los datos de los personajes");
    }
    private void SetUpSkills()
    {
        if (!File.Exists(SkillsFile)) throw new Exception("No existe el archivo de skills");
        string skillsJson = File.ReadAllText(SkillsFile);
        _skills = JsonSerializer.Deserialize<Skill[]>(skillsJson, _options)
                                 ?? throw new Exception("No fue posible obtener los datos de los skills");
    }
    private void ShowAvailableTeams()
    {
        for (int i = 0; i < _teamFiles.Length; i++)
        {
            string teamFile = Path.GetFileName(_teamFiles[i]);
            _view.WriteLine($"{i}: {teamFile}");
        }
    }
}