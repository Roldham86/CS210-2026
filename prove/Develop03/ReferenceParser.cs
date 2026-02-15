using System;
// Made by W00F
// Parses user input like "John 3:16" or "John 2:1-5" into a Reference object.
// This keeps parsing logic out of Program.cs and makes it reusable/testable.
public static class ReferenceParser
{
    public static Reference Parse(string input)
    {
    // // Validate input: "John 3:16" or "John 2:1-5" 
        if (string.IsNullOrWhiteSpace(input))
            throw new ArgumentException("Reference cannot be empty.");
        input = input.Trim();
    // Split on the LAST space so multi-word book names still work.
        int lastSpaceIndex = input.LastIndexOf(' ');
        if (lastSpaceIndex < 0 || lastSpaceIndex == input.Length - 1)
            throw new FormatException("Format should be like: John 3:16");
        string book = input.Substring(0, lastSpaceIndex).Trim();
        string rest = input.Substring(lastSpaceIndex + 1).Trim();
        if (string.IsNullOrWhiteSpace(book))
            throw new FormatException("Book name is missing. Example: John 3:16");
	// Split chapter and verse section on ':' (ex: "3:16" or "3:5-6").
        string[] parts = rest.Split(':');
        if (parts.Length != 2)
            throw new FormatException("Format should be like: John 3:16");
	// Parse the chapter number.
        if (!int.TryParse(parts[0], out int chapter) || chapter <= 0)
            throw new FormatException("Chapter must be a positive integer. Example: John 3:16");
	// Parse the verse or verse range.
        string versePart = parts[1].Trim();
        if (string.IsNullOrWhiteSpace(versePart))
            throw new FormatException("Verse is missing. Example: John 3:16");
	// If there's a '-', treat it as a range (start-end).
        if (versePart.Contains('-'))
        {
            string[] range = versePart.Split('-', StringSplitOptions.RemoveEmptyEntries);
            if (range.Length != 2)
                throw new FormatException("Verse range format should be like: John 2:1-5");

            if (!int.TryParse(range[0], out int startVerse) || startVerse <= 0)
                throw new FormatException("Start verse must be a positive integer.");

            if (!int.TryParse(range[1], out int endVerse) || endVerse <= 0)
                throw new FormatException("End verse must be a positive integer.");

            if (endVerse < startVerse)
                throw new FormatException("End verse must be greater than or equal to start verse.");

            return new Reference(book, chapter, startVerse, endVerse);
        }
	// Single verse case.
        else
        {
            if (!int.TryParse(versePart, out int verse) || verse <= 0)
                throw new FormatException("Verse must be a positive integer.");

            return new Reference(book, chapter, verse);
        }
    }
}

