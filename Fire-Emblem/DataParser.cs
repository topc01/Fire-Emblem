using System.Text.Json;
using System.Text.Json.Serialization;
using Fire_Emblem.Characters;
using Fire_Emblem.Skills;

namespace Fire_Emblem;

public class DataParser
{
    private readonly JsonSerializerOptions _options = new()
    {
        NumberHandling = JsonNumberHandling.AllowReadingFromString | 
                         JsonNumberHandling.WriteAsString,
        IncludeFields = true
    };
    public string[] RetrieveTeamFilesFromFolder(string teamsFolder)
    {
        if (!Directory.Exists(teamsFolder)) throw new Exception("No existe la carpeta de equipos");
        string[] teamFiles = Directory.GetFiles(teamsFolder, "*.txt").OrderBy(f => f).ToArray();
        return teamFiles;
    }
    public CharacterStats[] SetUpCharacters(string charactersFile)
    {
        if (!File.Exists(charactersFile)) throw new Exception("No existe el archivo de personajes");
        string charactersJson = File.ReadAllText(charactersFile);
        return JsonSerializer.Deserialize<CharacterStats[]>(charactersJson, _options)
                         ?? throw new Exception("No fue posible obtener los datos de los personajes");
    }
    public Skill[] SetUpSkills(string skillsFile)
    {
        if (!File.Exists(skillsFile)) throw new Exception("No existe el archivo de skills");
        string skillsJson = File.ReadAllText(skillsFile);
        return JsonSerializer.Deserialize<Skill[]>(skillsJson, _options)
                     ?? throw new Exception("No fue posible obtener los datos de los skills");
    }
    
}