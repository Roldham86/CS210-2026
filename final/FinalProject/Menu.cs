using System;
using System.Collections.Generic;

public class Menu
{
    private Circuit _circuit;
    private CircuitAnalyzer _analyzer;

    public Menu(Circuit circuit, CircuitAnalyzer analyzer)
    {
        _circuit = circuit;
        _analyzer = analyzer;
    }

    public void Run()
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine();
            Console.WriteLine("=== Net-Based Circuit Builder and Analyzer ===");
            Console.WriteLine("1. Add DC voltage source");
            Console.WriteLine("2. Add resistor");
            Console.WriteLine("3. Add capacitor");
            Console.WriteLine("4. Add inductor");
            Console.WriteLine("5. View circuit");
            Console.WriteLine("6. Reduce equivalent values");
            Console.WriteLine("7. Analyze simple loop");
            Console.WriteLine("8. Quit");
            Console.Write("Choose an option: ");

            string input = Console.ReadLine() ?? "";

            switch (input)
            {
                case "1":
                    AddVoltageSource();
                    break;
                case "2":
                    AddResistor();
                    break;
                case "3":
                    AddCapacitor();
                    break;
                case "4":
                    AddInductor();
                    break;
                case "5":
                    _circuit.DisplayCircuit();
                    break;
                case "6":
                    ReduceCircuit();
                    break;
                case "7":
                    AnalyzeCircuit();
                    break;
                case "8":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }

    private void AddVoltageSource()
    {
        double voltage = ReadDouble("Enter voltage (V): ");
        string net1 = ReadNet("Enter first net name: ");
        string net2 = ReadNet("Enter second net name: ");

        DCVoltageSource source = new DCVoltageSource(_circuit.GetNextComponentId(), voltage, net1, net2);
        _circuit.AddComponent(source);
        Console.WriteLine("Voltage source added.");
    }

    private void AddResistor()
    {
        double resistance = ReadDouble("Enter resistance (ohms): ");
        string net1 = ReadNet("Enter first net name: ");
        string net2 = ReadNet("Enter second net name: ");

        Resistor resistor = new Resistor(_circuit.GetNextComponentId(), resistance, net1, net2);
        _circuit.AddComponent(resistor);
        Console.WriteLine("Resistor added.");
    }

    private void AddCapacitor()
    {
        double capacitance = ReadDouble("Enter capacitance (F): ");
        string net1 = ReadNet("Enter first net name: ");
        string net2 = ReadNet("Enter second net name: ");

        Capacitor capacitor = new Capacitor(_circuit.GetNextComponentId(), capacitance, net1, net2);
        _circuit.AddComponent(capacitor);
        Console.WriteLine("Capacitor added.");
    }

    private void AddInductor()
    {
        double inductance = ReadDouble("Enter inductance (H): ");
        string net1 = ReadNet("Enter first net name: ");
        string net2 = ReadNet("Enter second net name: ");

        Inductor inductor = new Inductor(_circuit.GetNextComponentId(), inductance, net1, net2);
        _circuit.AddComponent(inductor);
        Console.WriteLine("Inductor added.");
    }

    private void ReduceCircuit()
    {
        AnalysisResult result = _analyzer.ReduceCircuit(_circuit);
        result.Display();
    }

    private void AnalyzeCircuit()
    {
        AnalysisResult result = _analyzer.AnalyzeSimpleLoop(_circuit);
        result.Display();
    }

    private double ReadDouble(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine() ?? "";

            if (double.TryParse(input, out double value) && value > 0)
            {
                return value;
            }

            Console.WriteLine("Please enter a valid positive number.");
        }
    }

    private string ReadNet(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string net = (Console.ReadLine() ?? "").Trim().ToLower();

            if (!string.IsNullOrWhiteSpace(net))
            {
                return net;
            }

            Console.WriteLine("Net name cannot be empty.");
        }
    }
}