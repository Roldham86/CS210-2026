// Made by W00F
// Represents one verse: its number and its text.
// ScriptureLibrary returns a list of these for single verses or ranges.
public class Verse
{
    public int Number { get; }
    public string Text { get; }

    public Verse(int number, string text)
    {
        Number = number;
        Text = text;
    }
}
