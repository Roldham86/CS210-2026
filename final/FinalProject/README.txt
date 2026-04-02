Net-Based Circuit Builder and Analyzer

Overview  
This project is a console-based circuit simulator written in C#. It allows users to construct electrical circuits using a flexible, net-based connection system and perform limited analysis and equivalent value reduction.

Unlike traditional fixed-layout simulations, this program allows arbitrary circuit construction by defining each component as connected between two named nets. This approach enables users to create a wide variety of circuit topologies while maintaining a structured and object-oriented design.

------------------------------------------------------------

Project Goals  
The primary goal of this project is to:
- Allow flexible, user-defined circuit construction   
- Support equivalent value reduction (series and parallel)  
- Perform basic analysis on simple valid circuits  
- Gracefully handle unsupported circuit configurations  

------------------------------------------------------------

Supported Components  
The simulator currently supports the following electrical components:

- DC Voltage Source  
- Resistor  
- Capacitor  
- Inductor  

Each component is defined by:
- A unique ID  
- A value (voltage, resistance, capacitance, or inductance)  
- Two connected nets (e.g., net_1, net_2)  

------------------------------------------------------------

Net-Based Design  
Instead of using wires explicitly, the program uses nets to represent connections.

A component is defined as:
Component between net_A and net_B

This allows:
- Flexible circuit construction  
- Easy detection of series and parallel relationships  
- Scalable design without complex graph structures  

------------------------------------------------------------

Features  

1. Arbitrary Circuit Construction  
Users can:
- Add components between any two nets  
- Create complex or unconventional circuit layouts  
- Build circuits without restrictions on topology  

------------------------------------------------------------

2. Equivalent Value Reduction  

The program detects and reduces components when possible.

Resistors:
- Series: R = R1 + R2  
- Parallel: 1/R = 1/R1 + 1/R2  

Capacitors:
- Series: 1/C = 1/C1 + 1/C2  
- Parallel: C = C1 + C2  

Inductors:
- Series: L = L1 + L2  
- Parallel: 1/L = 1/L1 + 1/L2  

Limitations:
- Only simple, clearly identifiable series and parallel relationships are reduced  
- Complex or branching circuits may not be reducible  

------------------------------------------------------------

3. Basic Circuit Analysis  

If a circuit forms a simple valid loop, the program can compute:

- Total equivalent resistance  
- Total voltage  
- Total current (using Ohm’s Law)  

Requirements for analysis:
- Exactly one DC voltage source  
- No branching (each net connects exactly two components)  
- Only resistive elements (no capacitors or inductors in analysis mode)  

------------------------------------------------------------

4. Error Handling  

If a circuit cannot be analyzed or reduced, the program will not crash.

Instead, it will return helpful messages such as:
- "Circuit is not a simple valid loop"  
- "Reduction not possible for this topology"  
- "Unsupported component type for analysis"  

------------------------------------------------------------

Object-Oriented Design  

This project demonstrates all four major OOP principles:

Abstraction  
- CircuitComponent serves as a base class for all components  

Encapsulation  
- Each component stores its own value and connected nets  
- Data is protected and accessed through methods  

Inheritance  
- Resistor, Capacitor, Inductor, and DCVoltageSource inherit from CircuitComponent  

Polymorphism  
Each component implements:
- CombineSeries(...)  
- CombineParallel(...)  

This allows the same method call to behave differently depending on component type.

------------------------------------------------------------

User Interface  

The program uses a simple console-based menu:

1. Add DC voltage source  
2. Add resistor  
3. Add capacitor  
4. Add inductor  
5. View circuit  
6. Reduce equivalent values  
7. Analyze simple loop  
8. Quit  

------------------------------------------------------------

Example Use Cases  

Example 1: Simple Series Circuit  

Input:
- Battery (9V) between net_1 and net_2  
- Resistor (100 ohms) between net_2 and net_3  
- Resistor (200 ohms) between net_3 and net_1  

Behavior:
- Detects series relationship  
- Combines resistors into 300 ohms  
- Computes current  

Output:
Equivalent resistance: 300 ohms  
Total voltage: 9 V  
Total current: 0.03 A  

------------------------------------------------------------

Example 2: Parallel Capacitors  

Input:
- Capacitor (10 F) between net_1 and net_2  
- Capacitor (20 F) between net_1 and net_2  

Behavior:
- Detects parallel configuration  
- Combines into 30 F  

Output:
Equivalent capacitance: 30 F  

------------------------------------------------------------

Example 3: Unsupported Circuit (Branching)  

Input:
- Multiple components branching from the same net  

Behavior:
- Cannot reduce or analyze  

Output:
Reduction failed: circuit contains branching and cannot be simplified.  

------------------------------------------------------------

Example 4: Invalid Analysis  

Input:
- Circuit includes capacitor and voltage source  

Behavior:
- Analysis rejected  

Output:
Analysis failed: only resistors supported in simple loop analysis.  

------------------------------------------------------------

Limitations  

This project intentionally limits scope to keep implementation manageable:

- No time-domain analysis (no capacitor charging or inductive transients)  
- No AC analysis  
- No full Kirchhoff or matrix solving  
- No graphical interface  
- Only simple loop analysis supported  

------------------------------------------------------------

Future Improvements  

Potential extensions include:
- Circuit saving and reading 
- Parallel/branch circuit solving  
- Graph-based circuit traversal  
- GUI interface (drag-and-drop builder)  
- AC analysis support  
- Time-domain simulation  

------------------------------------------------------------

Summary  

This project provides a flexible and extensible foundation for circuit simulation while focusing on strong object-oriented design. By combining a net-based structure with polymorphic component behavior, the program achieves both flexibility and clarity while remaining within a manageable scope.
