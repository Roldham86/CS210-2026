using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// Made by W00F
// Stores the reference + all word tokens, and handles hiding logic.
// Program.cs controls the loop, but Scripture controls the memorization state.
public class Scripture
{
    private readonly Reference _reference;
    private readonly List<Word> _words;
    private readonly Random _random = new Random();

    public Scripture(Reference reference, List<Verse> verses)
    {
        _reference = reference;
        _words = new List<Word>();
    // Convert verses into Word tokens.
    // Format: add a verse label token ("1:") + each word in the verse + a newline token.
        foreach (var verse in verses)
        {
            _words.Add(new Word($"{verse.Number}:"));
            foreach (string w in verse.Text.Split(' ', StringSplitOptions.RemoveEmptyEntries))
                _words.Add(new Word(w));
            _words.Add(new Word("\n"));
        }
    }
	
// Hide a few random visible words (stretch: only choose words not already hidden)
    public void HideRandomWords(int numberToHide)
    {
	// Make a list of words that are allowed to hide and are currently visible.
        var visibleWords = _words.Where(w => w.CanHide && !w.IsHidden).ToList();
        if (visibleWords.Count == 0) return;
	// Never try to hide more words than exist.
        numberToHide = Math.Min(numberToHide, visibleWords.Count);
	// Randomly select words to hide, removing each from the pool so it cant be picked again.
        for (int i = 0; i < numberToHide; i++)
        {
            int index = _random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }
	
// True when every hideable word is hidden.
    public bool IsCompletelyHidden()
    {
        return _words.Where(w => w.CanHide).All(w => w.IsHidden);
    }

// Builds the string shown on screen (reference + formatted verse text).
    public string GetDisplayText()
    {
        var sb = new StringBuilder();
	// Display the reference at the top.
        sb.Append(_reference.ToString());
        sb.Append("\n\n");
	// Append each token, for clenlyness.
        foreach (var w in _words)
        {
            string token = w.GetDisplayText();
            if (token == "\n")
            {
			// Remove any trailing space before a newline.
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
	// Trim trailing spaces/newlines at the very end.
        while (sb.Length > 0 && (sb[sb.Length - 1] == ' ' || sb[sb.Length - 1] == '\n'))
            sb.Length--;
        return sb.ToString();
    }
}
