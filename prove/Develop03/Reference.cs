// Made by W00F
// Represents a scripture reference like "John 3:16" or "John 3:5-6".
// This class stores the structured parts and formats them for display.
public class Reference
{
    private readonly string _book;
    private readonly int _chapter;
    private readonly int _startVerse;
    private readonly int? _endVerse;
	
// Constructor for a single verse reference.
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = verse;
        _endVerse = null;
    }
	
// Constructor for a verse range reference.
    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }
	
// Read-only properties to expose reference data safely.
    public string Book => _book;
    public int Chapter => _chapter;
    public int StartVerse => _startVerse;
    public int EndVerse => _endVerse ?? _startVerse; // If no range, EndVerse treated as StartVerse
    public bool IsRange => _endVerse != null; // True when reference created using range constructor.
	
// Convert to the user-friendly output on screen.
    public override string ToString()
    {
        if (!IsRange) return $"{_book} {_chapter}:{_startVerse}";
        return $"{_book} {_chapter}:{_startVerse}-{EndVerse}";
    }
}
