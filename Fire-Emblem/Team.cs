namespace Fire_Emblem;

public class Team
{
    public readonly int PlayerNumber;
    private readonly List<Character> _characters = new List<Character>();
    public Team(int playerNumber) => PlayerNumber = playerNumber;
    public bool HasLost() => !_characters.Any(character => character.IsAlive());
    public int Length => _characters.Count;
    public void AddCharacter(Character character) => _characters.Add(character.New());
    public bool IsValidTeam() => IsValidLength() && AllValidCharacters() && !HasRepeatedCharacters();
    private bool IsValidLength() => _characters.Count is >= 1 and <= 3;
    private bool AllValidCharacters() => _characters.All(chr => chr.IsValidCharacter());
    private bool HasRepeatedCharacters() => _characters.Count != _characters.Distinct().Count();
    public Character GetCharacter(int selected) => _characters[selected]
                                                   ?? throw new Exception("No se encontró en el equipo");
    public Character[] GetLiveCharacters()
        => _characters.Where(character => character.IsAlive()).ToArray();
}