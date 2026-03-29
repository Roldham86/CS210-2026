using System;

public class Capacitor : CircuitComponent
{
    private double _capacitance;

    public Capacitor(int componentId, double capacitance, string net1, string net2)
        : base(componentId, "Capacitor", net1, net2)
    {
        _capacitance = capacitance;
    }

    public double GetCapacitance()
    {
        return _capacitance;
    }

    public override bool CanCombineWith(CircuitComponent other)
    {
        return other is Capacitor;
    }

    public override CircuitComponent CombineSeries(CircuitComponent other, int newComponentId, string outerNet1, string outerNet2)
    {
        if (other is not Capacitor capacitor)
        {
            throw new InvalidOperationException("Capacitors can only be combined in series with other capacitors.");
        }

        double equivalentCapacitance = 1.0 / ((1.0 / _capacitance) + (1.0 / capacitor.GetCapacitance()));
        return new Capacitor(newComponentId, equivalentCapacitance, outerNet1, outerNet2);
    }

    public override CircuitComponent CombineParallel(CircuitComponent other, int newComponentId)
    {
        if (other is not Capacitor capacitor)
        {
            throw new InvalidOperationException("Capacitors can only be combined in parallel with other capacitors.");
        }

        double equivalentCapacitance = _capacitance + capacitor.GetCapacitance();
        return new Capacitor(newComponentId, equivalentCapacitance, _net1, _net2);
    }

    public override string GetComponentType()
    {
        return "Capacitor";
    }

    public override string GetValueString()
    {
        return $"{_capacitance} F";
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"[{_componentId}] Capacitor: {_capacitance} F between {_net1} and {_net2}");
    }
}