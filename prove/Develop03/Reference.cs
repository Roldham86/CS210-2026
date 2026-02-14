public class Reference
{
    private readonly string _book;
    private readonly int _chapter;
    private readonly int _startVerse;
    private readonly int? _endVerse;

    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = verse;
        _endVerse = null;
    }

    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }

    public string Book => _book;
    public int Chapter => _chapter;
    public int StartVerse => _startVerse;
    public int EndVerse => _endVerse ?? _startVerse;
    public bool IsRange => _endVerse != null;

    public override string ToString()
    {
        if (!IsRange) return $"{_book} {_chapter}:{_startVerse}";
        return $"{_book} {_chapter}:{_startVerse}-{EndVerse}";
    }
}
