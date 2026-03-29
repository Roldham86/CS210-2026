using System;

public class AnalysisResult
{
    private bool _isSuccessful;
    private string _message;
    private double _equivalentResistance;
    private double _equivalentCapacitance;
    private double _equivalentInductance;
    private double _totalVoltage;
    private double _totalCurrent;

    public AnalysisResult(bool isSuccessful, string message)
    {
        _isSuccessful = isSuccessful;
        _message = message;
        _equivalentResistance = 0;
        _equivalentCapacitance = 0;
        _equivalentInductance = 0;
        _totalVoltage = 0;
        _totalCurrent = 0;
    }

    public void SetResistance(double value)
    {
        _equivalentResistance = value;
    }

    public void SetCapacitance(double value)
    {
        _equivalentCapacitance = value;
    }

    public void SetInductance(double value)
    {
        _equivalentInductance = value;
    }

    public void SetVoltage(double value)
    {
        _totalVoltage = value;
    }

    public void SetCurrent(double value)
    {
        _totalCurrent = value;
    }

    public void Display()
    {
        Console.WriteLine();
        Console.WriteLine("=== Result ===");
        Console.WriteLine(_message);

        if (_equivalentResistance > 0)
        {
            Console.WriteLine($"Equivalent resistance: {_equivalentResistance} ohms");
        }

        if (_equivalentCapacitance > 0)
        {
            Console.WriteLine($"Equivalent capacitance: {_equivalentCapacitance} F");
        }

        if (_equivalentInductance > 0)
        {
            Console.WriteLine($"Equivalent inductance: {_equivalentInductance} H");
        }

        if (_totalVoltage > 0)
        {
            Console.WriteLine($"Total voltage: {_totalVoltage} V");
        }

        if (_totalCurrent > 0)
        {
            Console.WriteLine($"Total current: {_totalCurrent} A");
        }
    }
}