using Fire_Emblem_View;
using Fire_Emblem.Characters;

namespace Fire_Emblem;

public class Player
{
    public readonly int PlayerNumber;
    public readonly CharacterController Controller = new CharacterController();
    private readonly List<Character> _characters = new List<Character>();
    public Player(int playerNumber) => PlayerNumber = playerNumber;
    public bool HasLost() => !_characters.Any(character => character.IsAlive());
    public void AddCharacter(Character character) => _characters.Add(character);
    public bool IsValidTeam() => IsValidLength() && AllValidCharacters() && !HasRepeatedCharacters();
    private bool IsValidLength() => _characters.Count is >= 1 and <= 3;
    private bool AllValidCharacters() => _characters.All(chr => chr.IsValidCharacter());
    private bool HasRepeatedCharacters() => _characters.Count != _characters.Distinct().Count();
    private Character[] GetLiveCharacters()
        => _characters.Where(character => character.IsAlive()).ToArray();
    private void Print(Character[] characters, View view) 
        => characters
        .Select((character, i) => $"{i}: {character.Name}")
        .ToList()
        .ForEach(view.WriteLine);
    private void Choose(Character[] characters, View view)
    {
        int choice;
        while (!int.TryParse(view.ReadLine(), out choice) 
               || choice < 0 
               || choice >= characters.Length
               || !characters[choice].IsAlive()) ;
        Controller.SetCharacter(characters[choice]);
    }
    public void SelectValidCharacter(View view)
    {
        Character[] liveCharacters = GetLiveCharacters();
        view.WriteLine($"Player {PlayerNumber} selecciona una opción");
        Print(liveCharacters, view);
        Choose(liveCharacters, view);
    }
    public override string ToString() => $"{Controller.Name} (Player {PlayerNumber}) comienza";
    public string CharacterFinalStatus => $"{Controller}";
    public string AdvantageMessage(Player opponent) => Controller.CheckAdvantages(opponent.Controller);
}