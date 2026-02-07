using System;

public class Entry
{
// DATA //
    public string _date = "";
    public string _prompt = "";
    public string _response = "";

// FUNCT //
    public void Display()
    {
        Console.WriteLine($"Date: {_date} - Prompt: {_prompt}");
        Console.WriteLine(_response);
    }

    public string ToFileLine(string separator)
    {
        return $"{_date}{separator}{_prompt}{separator}{_response}";
    }

    public static Entry FromFileLine(string line, string separator)
    {
        string[] parts = line.Split(separator);

        Entry entry = new Entry();

        entry._date = parts[0];
        entry._prompt = parts[1];
        entry._response = string.Join(separator, parts, 2, parts.Length - 2);

        return entry;
    }
}