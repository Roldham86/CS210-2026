using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
// DATA //
    public List<Entry> _entries = new List<Entry>();
    private string _separator = "|";

// FUNCT //
    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("(Journal is empty)");
            return;
        }

        foreach (Entry entry in _entries)
        {
            entry.Display();
            Console.WriteLine();
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine($"SEP{_separator}");

            foreach (Entry entry in _entries)
            {
                writer.WriteLine(entry.ToFileLine(_separator));
            }
        }

        Console.WriteLine($"Saved {_entries.Count} entries to \"{filename}\"");
    }

    public void LoadFromFile(string filename)
    {
        string[] lines = File.ReadAllLines(filename);
        List<Entry> loaded = new List<Entry>();

        string separator = _separator;

        if (lines.Length > 0 && lines[0].StartsWith("SEP"))
        {
            separator = lines[0].Substring(3);
        }

        int startIndex = (lines[0].StartsWith("SEP")) ? 1 : 0;

        for (int i = startIndex; i < lines.Length; i++)
        {
            Entry entry = Entry.FromFileLine(lines[i], separator);
            loaded.Add(entry);
        }

        _entries = loaded;
        Console.WriteLine($"Loaded {_entries.Count} entries from \"{filename}\"");
    }
}