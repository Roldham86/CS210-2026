using System;

public class Fraction
{
    private int _top;
    private int _bottom;

// Constructors
    public Fraction()
    {
        _top = 1;
        _bottom = 1;
        Normalize();
    }

    public Fraction(int top)
    {
        _top = top;
        _bottom = 1;
        Normalize();
    }

    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
        Normalize();
    }

// Getters / Setters
    public int GetTop()
    {
        return _top;
    }

    public void SetTop(int top)
    {
        _top = top;
        Normalize();
    }

    public int GetBottom()
    {
        return _bottom;
    }

    public void SetBottom(int bottom)
    {
        _bottom = bottom;
        Normalize();
    }

// Representations
    public string GetFractionString()
    {
        return $"{_top}/{_bottom}";
    }

    public double GetDecimalValue()
    {
        return (double)_top / _bottom; 
    }

// Private helpers
    private void Normalize()
    {
    // Denominator cannot be 0
        if (_bottom == 0)
        {
            _bottom = 1; // safe default
        }

    // Keep denominator positive: move sign to numerator
        if (_bottom < 0)
        {
            _bottom = -_bottom;
            _top = -_top;
        }

    // If numerator is 0, force to 0/1
        if (_top == 0)
        {
            _bottom = 1;
            return;
        }

    // Reduce to simplest terms
        int g = Gcd(Math.Abs(_top), _bottom);
        _top /= g;
        _bottom /= g;
    }

    private int Gcd(int a, int b)
    {
        while (b != 0)
        {
            int r = a % b;
            a = b;
            b = r;
        }
        return a;
    }
}