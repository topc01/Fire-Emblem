using Fire_Emblem_View;
using Fire_Emblem.Character;

namespace Fire_Emblem;

public class Player
{
    public readonly int PlayerNumber;
    public readonly CharacterController Controller = new CharacterController();
    private readonly List<CharacterAnalyzer> _characters = new List<CharacterAnalyzer>();
    public Player(int playerNumber) => PlayerNumber = playerNumber;
    public bool HasLost() => !_characters.Any(character => character.IsAlive());
    public void AddCharacter(CharacterAnalyzer characterAnalyzer) => _characters.Add(characterAnalyzer);
    public bool IsValidTeam() => IsValidLength() && AllValidCharacters() && !HasRepeatedCharacters();
    private bool IsValidLength() => _characters.Count is >= 1 and <= 3;
    private bool AllValidCharacters() => _characters.All(chr => chr.IsValidCharacter());
    private bool HasRepeatedCharacters() => _characters.Count != _characters.Distinct().Count();
    private CharacterAnalyzer[] GetLiveCharacters()
        => _characters.Where(character => character.IsAlive()).ToArray();
    private void Print(CharacterAnalyzer[] characters, View view) 
        => characters
        .Select((character, i) => $"{i}: {character.Name}")
        .ToList()
        .ForEach(view.WriteLine);
    private void Choose(CharacterAnalyzer[] characters, View view)
    {
        int choice;
        while (!int.TryParse(view.ReadLine(), out choice) 
               || choice < 0 
               || choice >= characters.Length
               || !characters[choice].IsAlive()) ;
        Controller.Character = characters[choice].Character;
    }
    public void SelectValidCharacter(View view)
    {
        CharacterAnalyzer[] liveCharacters = GetLiveCharacters();
        view.WriteLine($"Player {PlayerNumber} selecciona una opción");
        Print(liveCharacters, view);
        Choose(liveCharacters, view);
    }
    public override string ToString() => $"{Controller.Name} (Player {PlayerNumber}) comienza";
    public string CharacterFinalStatus => $"{Controller}";
    public string AdvantageMessage(Player opponent) => Controller.CheckAdvantages(opponent.Controller);
}