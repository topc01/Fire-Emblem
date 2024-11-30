using Fire_Emblem_View;
using Fire_Emblem.Characters;
using Fire_Emblem.Types;

namespace Fire_Emblem;

public class Player
{
    public readonly int PlayerNumber;
    public readonly CharacterController Controller = new CharacterController();
    private readonly List<Character> _characters = new List<Character>();
    private const int MaxCharactersLength = 3;
    public Player(int playerNumber) => PlayerNumber = playerNumber;
    public bool HasLost() => !_characters.Any(character => character.IsAlive());
    public void AddCharacter(Character character) => _characters.Add(character);
    public bool IsValidTeam() => IsValidLength() && AllValidCharacters() && !HasRepeatedCharacters();
    private bool IsValidLength() => _characters.Count is >= 1 and <= MaxCharactersLength;
    private bool AllValidCharacters() => _characters.All(chr => chr.IsValidCharacter());
    //private bool HasRepeatedCharacters2() => _characters.Count != _characters.Distinct().Count();

    private bool HasRepeatedCharacters()
    {
        int characterCount = _characters.Count();
        IEnumerable<Character> distinctCharacters = _characters.Distinct();
        int distinctCharactersCount = distinctCharacters.Count();
        return characterCount != distinctCharactersCount;
    }
    private Character[] GetLiveCharacters()
        => _characters.Where(character => character.IsAlive()).ToArray();

    private void PrintCharacters(Character[] characters, View view)
    {
        IEnumerable<string> charactersWithMessage = characters.Select((character, i) => $"{i}: {character.Name}");
        List<string> charactersWithMessageList = charactersWithMessage.ToList();
        charactersWithMessageList.ForEach(view.WriteLine);
    }
    
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
        PrintCharacters(liveCharacters, view);
        Choose(liveCharacters, view);
    }
    public override string ToString() => $"{Controller.Character.Name} (Player {PlayerNumber}) comienza";
    public string CharacterFinalStatus => $"{Controller}";
    public string GetAdvantageMessage(Player opponent) => Controller.GetAdvantageMessage(opponent.Controller);

    public void ApplySkills(CharacterController rival, EffectType type)
    {
        Controller.ApplySkills(rival, type);
    }
}