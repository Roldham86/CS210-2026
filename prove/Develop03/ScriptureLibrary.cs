using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
//Made by W00F
public class ScriptureLibrary
{
    private readonly BibleBook _book;

    public ScriptureLibrary(string jsonPath)
    {
        string json = File.ReadAllText(jsonPath);

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        _book = JsonSerializer.Deserialize<BibleBook>(json, options)
            ?? throw new Exception("Failed to load Bible JSON.");
    }

    public List<Verse> GetVerses(Reference reference)
    {
        string chapterKey = reference.Chapter.ToString();

        if (!_book.Chapters.TryGetValue(chapterKey, out var verses))
            throw new Exception($"Chapter {reference.Chapter} not found in {_book.Book}.");

        var result = new List<Verse>();

        if (!reference.IsRange)
        {
            string verseKey = reference.StartVerse.ToString();
            if (!verses.TryGetValue(verseKey, out var text))
                throw new Exception($"Verse {reference.StartVerse} not found.");

            result.Add(new Verse(reference.StartVerse, text));
            return result;
        }

        for (int v = reference.StartVerse; v <= reference.EndVerse; v++)
        {
            string key = v.ToString();

            if (!verses.TryGetValue(key, out var verseText))
                throw new Exception($"Verse {v} not found.");

            result.Add(new Verse(v, verseText));
        }

        return result;
    }
}

