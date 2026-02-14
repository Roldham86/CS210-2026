//Made by W00F
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

    public bool CanHide
    {
        get
        {
            if (_text == "\n") return false;

            if (_text.EndsWith(":"))
            {
                string num = _text.TrimEnd(':');
                if (int.TryParse(num, out _)) return false; // verse label
            }

            return true;
        }
    }

    public void Hide()
    {
        if (CanHide) _isHidden = true;
    }

    public string GetDisplayText()
    {
        if (_text == "\n") return "\n";
        if (_isHidden) return new string('_', _text.Length);
        return _text;
    }
}



