using System;
//Made by W00F
public static class ReferenceParser
{
    public static Reference Parse(string input)
    {
        // Expect: "John 3:16" or "John 2:1-5"
        input = input.Trim();

        int spaceIndex = input.IndexOf(' ');
        if (spaceIndex < 0) throw new Exception("Format should be like: John 3:16");

        string book = input.Substring(0, spaceIndex).Trim();
        string rest = input.Substring(spaceIndex + 1).Trim();

        string[] parts = rest.Split(':');
        if (parts.Length != 2) throw new Exception("Format should be like: John 3:16");

        int chapter = int.Parse(parts[0]);
        string versePart = parts[1];

        if (versePart.Contains('-'))
        {
            string[] range = versePart.Split('-');
            int startVerse = int.Parse(range[0]);
            int endVerse = int.Parse(range[1]);
            return new Reference(book, chapter, startVerse, endVerse);
        }
        else
        {
            int verse = int.Parse(versePart);
            return new Reference(book, chapter, verse);
        }
    }
}
