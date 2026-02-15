using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
// Made by W00F
// Loads scripture data from a JSON file and provides verse lookup by Reference.
// This isolates file/JSON logic from the rest of the program.
public class ScriptureLibrary
{
    private readonly BibleBook _book;

    public ScriptureLibrary(string jsonPath)
    {
	// Read the entire JSON file into a string.
        string json = File.ReadAllText(jsonPath);
	// Configure JSON deserialization
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
	// Convert JSON into a BibleBook object.
        _book = JsonSerializer.Deserialize<BibleBook>(json, options)
            ?? throw new Exception("Failed to load Bible JSON.");
	// Validate that the JSON includes required fields.
        if (string.IsNullOrWhiteSpace(_book.Book) || _book.Chapters == null)
            throw new Exception("Bible JSON is missing required fields (Book/Chapters).");
    }

    public List<Verse> GetVerses(Reference reference)
    {
    // error for the referance not in JSON file 
        if (!reference.Book.Trim().Equals(_book.Book.Trim(), StringComparison.OrdinalIgnoreCase))
        {
            throw new Exception($"This library contains only '{_book.Book}'. You entered '{reference.Book}'.");
        }
	// Look up the chapter dictionary (chapter -> verses).
        string chapterKey = reference.Chapter.ToString();
        if (!_book.Chapters.TryGetValue(chapterKey, out var verses))
            throw new Exception($"Chapter {reference.Chapter} not found in {_book.Book}.");
        var result = new List<Verse>();
	// Single verse: return a list with exactly one Verse object.
        if (!reference.IsRange)
        {
            string verseKey = reference.StartVerse.ToString();
            if (!verses.TryGetValue(verseKey, out var text))
                throw new Exception($"Verse {reference.StartVerse} not found in chapter {reference.Chapter}.");
            result.Add(new Verse(reference.StartVerse, text));
            return result;
        }
	// Verse range: collect verses start->end in order.
        for (int v = reference.StartVerse; v <= reference.EndVerse; v++)
        {
            string key = v.ToString();
            if (!verses.TryGetValue(key, out var verseText))
                throw new Exception($"Verse {v} not found in chapter {reference.Chapter}.");
            result.Add(new Verse(v, verseText));
        }
        return result;
    }
}


