using System;

public class Inductor : CircuitComponent
{
    private double _inductance;

    public Inductor(int componentId, double inductance, string net1, string net2)
        : base(componentId, "Inductor", net1, net2)
    {
        _inductance = inductance;
    }

    public double GetInductance()
    {
        return _inductance;
    }

    public override bool CanCombineWith(CircuitComponent other)
    {
        return other is Inductor;
    }

    public override CircuitComponent CombineSeries(CircuitComponent other, int newComponentId, string outerNet1, string outerNet2)
    {
        if (other is not Inductor inductor)
        {
            throw new InvalidOperationException("Inductors can only be combined in series with other inductors.");
        }

        double equivalentInductance = _inductance + inductor.GetInductance();
        return new Inductor(newComponentId, equivalentInductance, outerNet1, outerNet2);
    }

    public override CircuitComponent CombineParallel(CircuitComponent other, int newComponentId)
    {
        if (other is not Inductor inductor)
        {
            throw new InvalidOperationException("Inductors can only be combined in parallel with other inductors.");
        }

        double equivalentInductance = 1.0 / ((1.0 / _inductance) + (1.0 / inductor.GetInductance()));
        return new Inductor(newComponentId, equivalentInductance, _net1, _net2);
    }

    public override string GetComponentType()
    {
        return "Inductor";
    }

    public override string GetValueString()
    {
        return $"{_inductance} H";
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"[{_componentId}] Inductor: {_inductance} H between {_net1} and {_net2}");
    }
}