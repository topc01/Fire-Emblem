
using System.Text.RegularExpressions;
using Fire_Emblem_View;
using Fire_Emblem.Characters;
using Fire_Emblem.Skills;

namespace Fire_Emblem;

public class TeamReader
{
    private readonly View _view;
    
    private string _selectedFile;
    private readonly string[] _teamFiles;
    
    private Func<string, CharacterStats> _characterLookUp;
    private Func<string, Skill> _skillLookUp;
    private readonly SkillFactory _skillFactory = new();

    private readonly Player _player1 = new(1);
    private readonly Player _player2 = new(2);
    public TeamReader(string[] teamFiles, View view)
    {
        _view = view;
        _teamFiles = teamFiles;
    }
    
    public void ChooseTeamFile()
    {
        _view.WriteLine("Elige un archivo para cargar los equipos");
        ShowAvailableTeams();
        int choice;
        while (!int.TryParse(_view.ReadLine(), out choice) 
               || choice < 0 
               || choice >= _teamFiles.Length) ;
        _selectedFile = _teamFiles[choice];
    }
    private void ShowAvailableTeams()
    {
        for (int i = 0; i < _teamFiles.Length; i++)
        {
            string teamFile = Path.GetFileName(_teamFiles[i]);
            _view.WriteLine($"{i}: {teamFile}");
        }
    }
    public void SetUpTeams()
    {
        if (!File.Exists(_selectedFile)) throw new Exception("No existe el archivo de equipo");
        string[] lines = File.ReadAllLines(_selectedFile);
        
        Player currentPlayer = _player1;
        foreach (var line in lines)
        {
            if (line == "Player 1 Team") currentPlayer = _player1;
            else if (line == "Player 2 Team") currentPlayer = _player2;
            Character? character = ParseLine(line);
            if (character != null)
                currentPlayer.AddCharacter(character);
        }
    }
    private Character? ParseLine(string inputLine)
    {
        // RegEx for a word followed by something inside parenthesis
        string pattern = @"^(\w+)(?:\s*\(([^)]+)\))?$";
        Match match = Regex.Match(inputLine, pattern);

        if (!(match.Success)) return null;
            
        string characterName = match.Groups[1].Value;
        CharacterStats characterStats = _characterLookUp(characterName);
        Character character = new Character(characterStats);
        if (match.Groups[2].Success)
        {
            string[] skillNames = match.Groups[2].Value.Split(',');
            Skill[] skills = skillNames.Select(_skillFactory.Create).ToArray();
            character.AddSkills(skills);
        }

        return character;
    }
    public void SetCharacterFinder(Func<string, CharacterStats> function)
        => _characterLookUp = function;
    public void SetSkillFinder(Func<string, Skill> function)
        => _skillLookUp = function;

    public bool AreValidTeams()
        => _player1.IsValidTeam() && _player2.IsValidTeam();

    public (Player, Player) GetTeams()
        => (_player1, _player2);

}