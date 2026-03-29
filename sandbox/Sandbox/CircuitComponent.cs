using System;
public abstract class CircuitComponent
{
    protected int _componentId;
    protected string _name;
    protected string _net1;
    protected string _net2;

    public CircuitComponent(int componentId, string name, string net1, string net2)
    {
        _componentId = componentId;
        _name = name;
        _net1 = net1;
        _net2 = net2;
    }

    public int GetComponentId()
    {
        return _componentId;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetNet1()
    {
        return _net1;
    }

    public string GetNet2()
    {
        return _net2;
    }

    public bool IsConnectedToNet(string net)
    {
        return _net1 == net || _net2 == net;
    }

    public bool SharesSameNets(CircuitComponent other)
    {
        return (_net1 == other.GetNet1() && _net2 == other.GetNet2()) ||
               (_net1 == other.GetNet2() && _net2 == other.GetNet1());
    }

    // Returns true when two components are the same family and can potentially be reduced together.
    public abstract bool CanCombineWith(CircuitComponent other);

    // Creates a new equivalent component for a valid series reduction.
    // The caller provides the two outside nets that remain after the shared series net is removed.
    public abstract CircuitComponent CombineSeries(CircuitComponent other, int newComponentId, string outerNet1, string outerNet2);

    // Creates a new equivalent component for a valid parallel reduction.
    // Parallel components keep the same two nets.
    public abstract CircuitComponent CombineParallel(CircuitComponent other, int newComponentId);

    public abstract string GetComponentType();
    public abstract string GetValueString();
    public abstract void DisplayInfo();
}
