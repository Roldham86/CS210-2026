using System;
//made by W00f
class Program
{
    static void Main(string[] args)
    {
        // Verify constructors
        Fraction f1 = new Fraction();        // 1/1
        Fraction f2 = new Fraction(6);       // 6/1
        Fraction f3 = new Fraction(6, 7);    // 6/7

        Console.WriteLine(f1.GetFractionString());
        Console.WriteLine(f1.GetDecimalValue());

        Console.WriteLine(f2.GetFractionString());
        Console.WriteLine(f2.GetDecimalValue());

        Console.WriteLine(f3.GetFractionString());
        Console.WriteLine(f3.GetDecimalValue());

        Console.WriteLine();

    // Verify getters and setters
        Fraction f4 = new Fraction();
        f4.SetTop(3);
        f4.SetBottom(4);

        Console.WriteLine(f4.GetTop());                 // 3
        Console.WriteLine(f4.GetBottom());              // 4
        Console.WriteLine(f4.GetFractionString());      // 3/4
        Console.WriteLine(f4.GetDecimalValue());        // 0.75

        Console.WriteLine();

    // More examples fractions 
        Fraction a = new Fraction();          // 1/1
        Fraction b = new Fraction(5);         // 5/1
        Fraction c = new Fraction(3, 4);      // 3/4
        Fraction d = new Fraction(1, 3);      // 1/3

        Console.WriteLine(a.GetFractionString());
        Console.WriteLine(a.GetDecimalValue());

        Console.WriteLine(b.GetFractionString());
        Console.WriteLine(b.GetDecimalValue());

        Console.WriteLine(c.GetFractionString());
        Console.WriteLine(c.GetDecimalValue());

        Console.WriteLine(d.GetFractionString());
        Console.WriteLine(d.GetDecimalValue());

        Console.WriteLine();

    // ----- Game loop (20+) -----
        Random rand = new Random();
        Fraction practice = new Fraction();

        for (int i = 1; i <= 20; i++)
        {
            int top = rand.Next(-10, 11);     // -10..10
            int bottom = rand.Next(-10, 11);  // -10..10 (could be 0)

            practice.SetTop(top);
            practice.SetBottom(bottom);

            Console.WriteLine($"Fraction {i}: string: {practice.GetFractionString()} Number: {practice.GetDecimalValue()}");
        }
    }
}