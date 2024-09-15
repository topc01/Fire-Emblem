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
    private Character[] _characters;
    private const string SkillsFile = "skills.json";
    private Skill[] _skills;
    private readonly Team _player1Team;
    private readonly Team _player2Team;
    private bool _isPlayer1Turn;
    private int _round = 1;
    private readonly JsonSerializerOptions _options = new JsonSerializerOptions()
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
        _player1Team = new Team(1);
        _player2Team = new Team(2);
        _isPlayer1Turn = true;
    }

    public void Play()
    {
        ChooseFile();
        if (!(_player1Team.IsValidTeam() && _player2Team.IsValidTeam()))
        {
            _view.WriteLine("Archivo de equipos no válido");
            return;
        }

        while (!_player1Team.HasLost() && !_player2Team.HasLost())  
            PlayTurn();

        Team winner = _player1Team.HasLost() ? _player2Team : _player1Team;
        _view.WriteLine($"Player {winner.PlayerNumber} ganó");
    }

    private void PlayTurn()
    {
        Team currentPlayerTeam = _isPlayer1Turn ? _player1Team : _player2Team;
        Team opponentTeam = _isPlayer1Turn ? _player2Team : _player1Team;
        
        _view.WriteLine($"Player {currentPlayerTeam.PlayerNumber} selecciona una opción");
        Character[] liveCharactersCurrentTeam = currentPlayerTeam.GetLiveCharacters();
        for (int i = 0; i < liveCharactersCurrentTeam.Length; i++)
            _view.WriteLine($"{i}: {liveCharactersCurrentTeam[i].Name}");
        Character attacker = SelectCharacter(liveCharactersCurrentTeam);
        
        _view.WriteLine($"Player {opponentTeam.PlayerNumber} selecciona una opción");
        Character[] liveCharactersOpponentTeam = opponentTeam.GetLiveCharacters();
        for (int i = 0; i < liveCharactersOpponentTeam.Length; i++)
            _view.WriteLine($"{i}: {liveCharactersOpponentTeam[i].Name}");
        Character defender = SelectCharacter(liveCharactersOpponentTeam);
        
        _view.WriteLine($"Round {_round}: {attacker.Name} (Player {currentPlayerTeam.PlayerNumber}) comienza");
        _view.WriteLine(attacker.CheckAdvantages(defender));
        StartBattle(attacker, defender);
        _view.WriteLine(FinalState(attacker, defender));
        _isPlayer1Turn = !_isPlayer1Turn;
        _round++;
    }

    private static string FinalState(Character attacker, Character defender)
        => $"{attacker} : {defender}";

    private void StartBattle(Character attacker, Character defender)
    {
        // Attack
        _view.WriteLine(attacker.Attack(defender));
        // If defender is dead, finish
        if (!defender.IsAlive()) return;
        // Counter attack
        _view.WriteLine(defender.Attack(attacker));
        // If attacker is dead, finish
        if (!attacker.IsAlive()) return;
        // Follow up
        if (attacker.CanFollowUp(defender))
            _view.WriteLine(attacker.Attack(defender));
        else if (defender.CanFollowUp(attacker))
            _view.WriteLine(defender.Attack(attacker));
        else _view.WriteLine("Ninguna unidad puede hacer un follow up");
    }

    private Character SelectCharacter(Character[] liveCharacters)
    {
        int choice;
        while (!int.TryParse(_view.ReadLine(), out choice) 
               || choice < 0 
               || choice >= liveCharacters.Length
               || !liveCharacters[choice].IsAlive()) ;
        return liveCharacters[choice];
    }
    private void ChooseFile()
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
        
        Team currentTeam = _player1Team;
        foreach (var line in lines)
        {
            if (line == "Player 1 Team") currentTeam = _player1Team;
            else if (line == "Player 2 Team") currentTeam = _player2Team;
            else
            {
                Character? character = ParseLine(line);
                if (character != null)
                    currentTeam.AddCharacter(character);
            }
        }
    }
    private Character? ParseLine(string line)
    {
        string pattern = @"^(\w+)(?:\s*\(([^)]+)\))?$";
        Match match = Regex.Match(line, pattern);

        if (!(match.Success)) return null;
            
        string characterName = match.Groups[1].Value;
        Character character = FindCharacterByName(characterName);
        if (match.Groups[2].Success)
        {
            string[] skillNames = match.Groups[2].Value.Split(',');
            Skill[] skills = skillNames.Select(FindSkillByName).ToArray();
            character.AddSkills(skills);
        }

        return character;
    }
    private Character FindCharacterByName(string characterName)
        => Array.Find(_characters, chr => chr.Name == characterName) ?? 
            throw new Exception("No se encontro el personaje");
    private Skill FindSkillByName(string skillName) 
        => Array.Find(_skills, skl => skl.Name == skillName) ?? 
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
        _characters = JsonSerializer.Deserialize<Character[]>(charactersJson, _options)
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