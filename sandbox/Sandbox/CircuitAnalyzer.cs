using System;
using System.Collections.Generic;
using System.Linq;

public class CircuitAnalyzer
{
    public AnalysisResult ReduceCircuit(Circuit circuit)
    {
        List<CircuitComponent> working = circuit.GetComponents();

        if (working.Count == 0)
        {
            return new AnalysisResult(false, "Reduction failed: circuit is empty.");
        }

        bool reducedSomething;

        do
        {
            reducedSomething = false;

            if (TryReduceParallel(working, circuit))
            {
                reducedSomething = true;
                continue;
            }

            if (TryReduceSeries(working, circuit))
            {
                reducedSomething = true;
            }
        }
        while (reducedSomething);

        circuit.ReplaceComponents(working);

        AnalysisResult result = new AnalysisResult(true, "Reduction complete.");

        foreach (CircuitComponent component in working)
        {
            if (component is Resistor resistor)
            {
                result.SetResistance(resistor.GetResistance());
            }
            else if (component is Capacitor capacitor)
            {
                result.SetCapacitance(capacitor.GetCapacitance());
            }
            else if (component is Inductor inductor)
            {
                result.SetInductance(inductor.GetInductance());
            }
        }

        return result;
    }

    public AnalysisResult AnalyzeSimpleLoop(Circuit circuit)
    {
        List<CircuitComponent> components = circuit.GetComponents();

        if (components.Count == 0)
        {
            return new AnalysisResult(false, "Analysis failed: circuit is empty.");
        }

        if (circuit.CountVoltageSources() != 1)
        {
            return new AnalysisResult(false, "Analysis failed: simple loop analysis requires exactly one DC voltage source.");
        }

        Dictionary<string, List<CircuitComponent>> netMap = circuit.BuildNetMap();

        foreach (var entry in netMap)
        {
            if (entry.Value.Count != 2)
            {
                return new AnalysisResult(false, "Analysis failed: circuit is not a simple valid loop.");
            }
        }

        double totalVoltage = 0;
        double totalResistance = 0;

        foreach (CircuitComponent component in components)
        {
            if (component is DCVoltageSource source)
            {
                totalVoltage += source.GetVoltage();
            }
            else if (component is Resistor resistor)
            {
                totalResistance += resistor.GetResistance();
            }
            else if (component is Capacitor || component is Inductor)
            {
                return new AnalysisResult(false, "Analysis failed: simple loop DC analysis currently supports resistors and one DC voltage source only.");
            }
        }

        if (totalResistance <= 0)
        {
            return new AnalysisResult(false, "Analysis failed: total resistance must be greater than zero.");
        }

        double current = totalVoltage / totalResistance;

        AnalysisResult result = new AnalysisResult(true, "Simple loop analysis successful.");
        result.SetVoltage(totalVoltage);
        result.SetResistance(totalResistance);
        result.SetCurrent(current);
        return result;
    }

    private bool TryReduceParallel(List<CircuitComponent> components, Circuit circuit)
    {
        for (int i = 0; i < components.Count; i++)
        {
            for (int j = i + 1; j < components.Count; j++)
            {
                CircuitComponent first = components[i];
                CircuitComponent second = components[j];

                if (!first.SharesSameNets(second))
                {
                    continue;
                }

                if (!first.CanCombineWith(second))
                {
                    continue;
                }

                CircuitComponent equivalent = first.CombineParallel(second, circuit.GetNextComponentId());

                components.RemoveAt(j);
                components.RemoveAt(i);
                components.Add(equivalent);
                return true;
            }
        }

        return false;
    }

    private bool TryReduceSeries(List<CircuitComponent> components, Circuit circuit)
    {
        Dictionary<string, List<CircuitComponent>> netMap = BuildNetMap(components);

        foreach (var entry in netMap)
        {
            if (entry.Value.Count != 2)
            {
                continue;
            }

            CircuitComponent first = entry.Value[0];
            CircuitComponent second = entry.Value[1];

            if (first is DCVoltageSource || second is DCVoltageSource)
            {
                continue;
            }

            if (!first.CanCombineWith(second))
            {
                continue;
            }

            string sharedNet = entry.Key;
            string outerNet1 = first.GetNet1() == sharedNet ? first.GetNet2() : first.GetNet1();
            string outerNet2 = second.GetNet1() == sharedNet ? second.GetNet2() : second.GetNet1();

            if (outerNet1 == outerNet2)
            {
                continue;
            }

            CircuitComponent equivalent = first.CombineSeries(second, circuit.GetNextComponentId(), outerNet1, outerNet2);

            components.Remove(first);
            components.Remove(second);
            components.Add(equivalent);
            return true;
        }

        return false;
    }

    private Dictionary<string, List<CircuitComponent>> BuildNetMap(List<CircuitComponent> components)
    {
        Dictionary<string, List<CircuitComponent>> netMap = new Dictionary<string, List<CircuitComponent>>();

        foreach (CircuitComponent component in components)
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
}