﻿using System.Text.Json;
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
    
    private readonly DataParser _dataParser = new();
    private readonly TeamReader _teamReader;
    public Game(View view, string teamsFolder)
    {
        _view = view;
        _teamFiles = _dataParser.RetrieveTeamFilesFromFolder(teamsFolder);
        _allCharacters = _dataParser.SetUpCharacters(CharactersFile);
        _allSkills = _dataParser.SetUpSkills(SkillsFile);
        _teamReader = new TeamReader(_teamFiles, _view);
    }

    public void Play()
    {
        _teamReader.ChooseTeamFile();
        _teamReader.SetCharacterFinder(FindCharacterStatsByName);
        _teamReader.SetSkillFinder(FindSkillByName);
        _teamReader.SetUpTeams();
        if (!(_teamReader.AreValidTeams()))
        {
            _view.WriteLine("Archivo de equipos no válido");
            return;
        }

        (Player player1, Player player2) = _teamReader.GetTeams();
        
        Combat combat = new(player1, player2, _view);
        
        while (combat.Continues())
        {
            combat.Battle();
            combat.SetNextRound();
        }

        Player winner = player1.HasLost() ? player2 : player1;
        _view.WriteLine($"Player {winner.PlayerNumber} ganó");
    }
    private CharacterStats FindCharacterStatsByName(string characterName)
        => Array.Find(_allCharacters, character => character.Name == characterName) ?? 
           throw new Exception("No se encontro el personaje");
    private Skill FindSkillByName(string skillName) 
        => Array.Find(_allSkills, skill => skill.Name == skillName) ?? 
           throw new Exception("No se encontro el skill");
    
}