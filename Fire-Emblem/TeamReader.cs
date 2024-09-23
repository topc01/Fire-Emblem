using System.Text.RegularExpressions;
using Fire_Emblem_View;
using Fire_Emblem.Character;

namespace Fire_Emblem;

public class TeamReader
{
    private readonly View _view;
    private readonly string[] _teamFiles;
    public TeamReader(string teamsFolder, View view)
    {
        _view = view;
        
        if (!Directory.Exists(teamsFolder)) throw new Exception("No existe la carpeta de equipos");
        _teamFiles = Directory.GetFiles(teamsFolder, "*.txt").OrderBy(f => f).ToArray();
    }
    
    private void ChooseTeamFile()
    {
        _view.WriteLine("Elige un archivo para cargar los equipos");
        ShowAvailableTeams();
        int choice;
        while (!int.TryParse(_view.ReadLine(), out choice) 
               || choice < 0 
               || choice >= _teamFiles.Length) ;
        SetUpTeam(_teamFiles[choice]);
    }
    private void ShowAvailableTeams()
    {
        for (int i = 0; i < _teamFiles.Length; i++)
        {
            string teamFile = Path.GetFileName(_teamFiles[i]);
            _view.WriteLine($"{i}: {teamFile}");
        }
    }
    private void SetUpTeam(string teamFile)
    {
        if (!File.Exists(teamFile)) throw new Exception("No existe el archivo de equipo");
        string[] lines = File.ReadAllLines(teamFile);
        
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
        CharacterStats characterStats = FindCharacterStatsByName(characterName);
        CharacterAnalyzer characterAnalyzer = new CharacterAnalyzer(characterStats);
        if (match.Groups[2].Success)
        {
            string[] skillNames = match.Groups[2].Value.Split(',');
            Skill[] skills = skillNames.Select(FindSkillByName).ToArray();
            characterAnalyzer.AddSkills(skills);
        }

        return characterAnalyzer;
    }
}