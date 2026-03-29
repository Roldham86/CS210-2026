using System;
using System.Collections.Generic;
using System.Linq;

public class Circuit
{
    private List<CircuitComponent> _components;
    private int _nextComponentId;

    public Circuit()
    {
        _components = new List<CircuitComponent>();
        _nextComponentId = 1;
    }

    public void AddComponent(CircuitComponent component)
    {
        _components.Add(component);
    }

    public int GetNextComponentId()
    {
        int id = _nextComponentId;
        _nextComponentId++;
        return id;
    }

    public List<CircuitComponent> GetComponents()
    {
        return new List<CircuitComponent>(_components);
    }

    public void ReplaceComponents(List<CircuitComponent> newComponents)
    {
        _components = newComponents;
    }

    public void DisplayCircuit()
    {
        Console.WriteLine();
        Console.WriteLine("=== Circuit Contents ===");

        if (_components.Count == 0)
        {
            Console.WriteLine("Circuit is empty.");
            return;
        }

        foreach (CircuitComponent component in _components)
        {
            component.DisplayInfo();
        }
    }

    public Dictionary<string, List<CircuitComponent>> BuildNetMap()
    {
        Dictionary<string, List<CircuitComponent>> netMap = new Dictionary<string, List<CircuitComponent>>();

        foreach (CircuitComponent component in _components)
        {
            if (!netMap.ContainsKey(component.GetNet1()))
            {
                netMap[component.GetNet1()] = new List<CircuitComponent>();
            }

            if (!netMap.ContainsKey(component.GetNet2()))
            {
                netMap[component.GetNet2()] = new List<CircuitComponent>();
            }

            netMap[component.GetNet1()].Add(component);
            netMap[component.GetNet2()].Add(component);
        }

        return netMap;
    }

    public int CountVoltageSources()
    {
        return _components.Count(c => c is DCVoltageSource);
    }
}