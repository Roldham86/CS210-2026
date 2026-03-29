using System;

public class DCVoltageSource : CircuitComponent
{
    private double _voltage;

    public DCVoltageSource(int componentId, double voltage, string net1, string net2)
        : base(componentId, "DC Voltage Source", net1, net2)
    {
        _voltage = voltage;
    }

    public double GetVoltage()
    {
        return _voltage;
    }

    public override bool CanCombineWith(CircuitComponent other)
    {
        return false;
    }

    public override CircuitComponent CombineSeries(CircuitComponent other, int newComponentId, string outerNet1, string outerNet2)
    {
        throw new InvalidOperationException("DC voltage sources are not supported in series reduction.");
    }

    public override CircuitComponent CombineParallel(CircuitComponent other, int newComponentId)
    {
        throw new InvalidOperationException("DC voltage sources are not supported in parallel reduction.");
    }

    public override string GetComponentType()
    {
        return "DCVoltageSource";
    }

    public override string GetValueString()
    {
        return $"{_voltage} V";
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"[{_componentId}] DC Voltage Source: {_voltage} V between {_net1} and {_net2}");
    }
}