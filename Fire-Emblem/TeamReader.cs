using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using Fire_Emblem_View;
using Fire_Emblem.Character;
using Fire_Emblem.Skills;

namespace Fire_Emblem;

public class TeamReader
{
    private readonly View _view;
    
    private string _selectedFile;
    private readonly string[] _teamFiles;
    
    private Func<string, CharacterStats> _characterLookUp;
    private Func<string, Skill> _skillLookUp;

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
            CharacterAnalyzer? character = ParseLine(line);
            if (character != null)
                currentPlayer.AddCharacter(character);
        }
    }
    private CharacterAnalyzer? ParseLine(string line)
    {
        string pattern = @"^(\w+)(?:\s*\(([^)]+)\))?$";
        Match match = Regex.Match(line, pattern);

        if (!(match.Success)) return null;
            
        string characterName = match.Groups[1].Value;
        CharacterStats characterStats = _characterLookUp(characterName);
        CharacterAnalyzer characterAnalyzer = new CharacterAnalyzer(characterStats);
        if (match.Groups[2].Success)
        {
            string[] skillNames = match.Groups[2].Value.Split(',');
            Skill[] skills = skillNames.Select(_skillLookUp).ToArray();
            characterAnalyzer.AddSkills(skills);
        }

        return characterAnalyzer;
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