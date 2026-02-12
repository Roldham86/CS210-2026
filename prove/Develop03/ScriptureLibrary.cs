using System;
using System.IO;
using System.Linq;
using System.Text.Json;

public class ScriptureLibrary
{
    private readonly BibleBook _book;

    public ScriptureLibrary(string jsonPath)
    {
        string json = File.ReadAllText(jsonPath);

        _book = JsonSerializer.Deserialize<BibleBook>(json)
            ?? throw new Exception("Failed to load Bible JSON.");
    }

    // Builds the full scripture text for either a single verse or a range
    public string GetText(Reference reference)
    {
        string chapterKey = reference.Chapter.ToString();

        if (!_book.Chapters.TryGetValue(chapterKey, out var verses))
            throw new Exception($"Chapter {reference.Chapter} not found in {_book.Book}.");

        if (!reference.IsRange)
        {
            string verseKey = reference.StartVerse.ToString();
            if (!verses.TryGetValue(verseKey, out var text))
                throw new Exception($"Verse {reference.StartVerse} not found.");

            return text;
        }
        else
        {
            // Range: concatenate verses in order
            var parts = Enumerable.Range(reference.StartVerse, reference.EndVerse - reference.StartVerse + 1)
                .Select(v =>
                {
                    string key = v.ToString();
                    if (!verses.TryGetValue(key, out var t))
                        throw new Exception($"Verse {v} not found.");
                    return t;
                });

            return string.Join(" ", parts);
        }
    }
}
