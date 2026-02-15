using System.Collections.Generic;
using System.Text.Json.Serialization;
// Made by W00F
// Data transfer object used for JSON deserialization.
// This represents the shape of Bible.json: book name + chapters + verses.
public class BibleBook
{
// JsonInclude allows System.Text.Json to set private setters during deserialization.
    [JsonInclude]
    public string Book { get; private set; } = "";
// Chapters[chapterNumber][verseNumber] = verseText
    [JsonInclude]
    public Dictionary<string, Dictionary<string, string>> Chapters { get; private set; } = new();
}
