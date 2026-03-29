using System;

class Program
{
    static void Main(string[] args)
    {
        Circuit circuit = new Circuit();
        CircuitAnalyzer analyzer = new CircuitAnalyzer();
        Menu menu = new Menu(circuit, analyzer);
        menu.Run();
    }
}

