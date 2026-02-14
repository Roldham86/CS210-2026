using System.Collections.Generic;
//Made by W00F
public class BibleBook
{
    public string Book { get; set; } = "";
    public Dictionary<string, Dictionary<string, string>> Chapters { get; set; }
        = new();
}

