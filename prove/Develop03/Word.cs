// Made by W00F
// Represents one token in the memorization text.
// Most tokens are normal words, but some are special (verse labels "1:" and newline "\n").
public class Word
{
    private readonly string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }
    public bool IsHidden => _isHidden;
	
// Determines whether this token is allowed to be hidden.
    public bool CanHide
    {
        get
        {
		// Never hide newline tokens (used for formatting).
            if (_text == "\n") return false;
		// If the token looks like a verse label ("12:"), do not hide it.
            if (_text.EndsWith(":"))
            {
                string num = _text.TrimEnd(':');
                if (int.TryParse(num, out _)) return false; // verse label
            }
            return true;
        }
    }
	
// Hide if is hideable.
    public void Hide()
    {
        if (CanHide) _isHidden = true;
    }
	
// Returns what should be printed for this token
    public string GetDisplayText()
    {
        if (_text == "\n") return "\n";
        if (_isHidden) return new string('_', _text.Length);
        return _text;
    }
}



