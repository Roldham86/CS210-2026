/*
CREATIVITY/EXCEEDING REQUIREMENTS:
- Added support for loading scripture text from an external JSON file (Bible.json).
- User can type any reference or verse range (ex: John 3:16 or John 2:1-5); the program parses it, pulls the verse(s) from the JSON library, then runs the standard word-hiding memorization loop.
- Implemented the stretch behavior where only words that are not already hidden are selected to hide next.
*/

#nullable enable
using System;
using System.Collections.Generic;
// Made by W00F
// Main entry point / UI controller.
// This class is responsible for user input/output and orchestrating the other classes.
class Program
{
    static void Main()
    {
	// Load the scripture library from the JSON database file.
        var library = new ScriptureLibrary("Bible.json");
	// Ask the user what they want to memorize.
        Console.Write("Enter a scripture to memorize (ex: John 3:16 or John 2:1-5): ");
        string? input = Console.ReadLine();
	// Basic input validation.
        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("No reference entered. Exiting.");
            return;
        }
	// Convert the user's typed reference into structured Reference object.
        Reference reference;
        try
        {
            reference = ReferenceParser.Parse(input);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Invalid reference: {ex.Message}");
            return;
        }
	// Use the Reference to pull verse text from the JSON library.
        List<Verse> verses;
        try
        {
            verses = library.GetVerses(reference);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Could not load scripture text: {ex.Message}");
            return;
        }
	// Create the memorization object (Reference + verse text converted into Word tokens).
        var scripture = new Scripture(reference, verses);
	// Main memorization loop: display -> prompt -> hide more -> repeat til done.
        while (true)
        {
            Console.Clear();
		// Display current state
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
		// End automatically when all hideable words are hidden.
            if (scripture.IsCompletelyHidden())
                break;
		// Wait for user action: Enter continues, "quit" exits.
            Console.Write("Press Enter to hide words or type 'quit' to exit: ");
            string? cmd = Console.ReadLine();

            if (cmd != null && cmd.Trim().Equals("quit", StringComparison.OrdinalIgnoreCase))
                break;
		// Hide a few more random words each round.
            scripture.HideRandomWords(3);
        }
    }
}
