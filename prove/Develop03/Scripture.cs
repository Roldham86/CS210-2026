using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//Made by W00F
public class Scripture
{
    private readonly Reference _reference;
    private readonly List<Word> _words;
    private static readonly Random _random = new Random();


    public Scripture(Reference reference, List<Verse> verses)
    {
        _reference = reference;
        _words = new List<Word>();

        // Add verses as:
        // "1:" token (locked) + verse words + newline token (locked)
        foreach (var verse in verses)
        {
            _words.Add(new Word($"{verse.Number}:"));

            foreach (string w in verse.Text.Split(' ', StringSplitOptions.RemoveEmptyEntries))
                _words.Add(new Word(w));

            _words.Add(new Word("\n"));
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        var visibleWords = _words.Where(w => w.CanHide && !w.IsHidden).ToList();
        if (visibleWords.Count == 0) return;

        numberToHide = Math.Min(numberToHide, visibleWords.Count);

        for (int i = 0; i < numberToHide; i++)
        {
            int index = _random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }

    public bool IsCompletelyHidden()
    {
        return _words.Where(w => w.CanHide).All(w => w.IsHidden);
    }

    public string GetDisplayText()
    {
        var sb = new StringBuilder();
        sb.Append(_reference.ToString());
        sb.Append("\n\n");

        foreach (var w in _words)
        {
            string token = w.GetDisplayText();

            if (token == "\n")
            {
                if (sb.Length > 0 && sb[sb.Length - 1] == ' ')
                    sb.Length--;

                sb.Append('\n');
            }
            else
            {
                sb.Append(token);
                sb.Append(' ');
            }
        }

        while (sb.Length > 0 && (sb[sb.Length - 1] == ' ' || sb[sb.Length - 1] == '\n'))
            sb.Length--;

        return sb.ToString();
    }
}
