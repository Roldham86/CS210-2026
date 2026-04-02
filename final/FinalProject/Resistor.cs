using System;

public class Resistor : CircuitComponent
{
    private double _resistance;

    public Resistor(int componentId, double resistance, string net1, string net2)
        : base(componentId, "Resistor", net1, net2)
    {
        _resistance = resistance;
    }

    public double GetResistance()
    {
        return _resistance;
    }

    public override bool CanCombineWith(CircuitComponent other)
    {
        return other is Resistor;
    }

    public override CircuitComponent CombineSeries(CircuitComponent other, int newComponentId, string outerNet1, string outerNet2)
    {
        if (other is not Resistor resistor)
        {
            throw new InvalidOperationException("Resistors can only be combined in series with other resistors.");
        }

        double equivalentResistance = _resistance + resistor.GetResistance();
        return new Resistor(newComponentId, equivalentResistance, outerNet1, outerNet2);
    }

    public override CircuitComponent CombineParallel(CircuitComponent other, int newComponentId)
    {
        if (other is not Resistor resistor)
        {
            throw new InvalidOperationException("Resistors can only be combined in parallel with other resistors.");
        }

        double equivalentResistance = 1.0 / ((1.0 / _resistance) + (1.0 / resistor.GetResistance()));
        return new Resistor(newComponentId, equivalentResistance, _net1, _net2);
    }

    public override string GetComponentType()
    {
        return "Resistor";
    }

    public override string GetValueString()
    {
        return $"{_resistance} ohms";
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"[{_componentId}] Resistor: {_resistance} ohms between {_net1} and {_net2}");
    }
}