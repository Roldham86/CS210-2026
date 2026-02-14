#nullable enable
using System;
using System.Collections.Generic;
//Made by W00F
class Program
{
    static void Main()
    {
        var library = new ScriptureLibrary("Bible.json");

        Console.Write("Enter a scripture to memorize (ex: John 3:16 or John 2:1-5): ");
        string? input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("No reference entered. Exiting.");
            return;
        }

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

        var scripture = new Scripture(reference, verses);

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();

            if (scripture.IsCompletelyHidden())
                break;

            Console.Write("Press Enter to hide words or type 'quit' to exit: ");
            string? cmd = Console.ReadLine();

            if (cmd != null && cmd.Trim().Equals("quit", StringComparison.OrdinalIgnoreCase))
                break;

            scripture.HideRandomWords(3);
        }
    }
}
