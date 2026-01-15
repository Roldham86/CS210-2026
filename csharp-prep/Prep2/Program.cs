using System;
// made by w00f
class Program
{
    static void Main(string[] args)
    {
    // intial declarations
        string letter   = "!!Error: no value assined loc<letter>!!";
        string message  = "!!Error: no value assined loc<message>!!";
        string modifier = "!!Error: no value assined loc<modifier>!!";

    // prompt for grade
        Console.Write("What is your grade percentage: ");
        string gradeStr = Console.ReadLine();

    // convert grade to int 
        if (!int.TryParse(gradeStr, out int grade))
        {
            Console.WriteLine("!!Error: invalid number input!!");
            return;
        }

    // validate grade range
        if (grade < 0 || grade > 100)
        {
            Console.WriteLine("!!Error: grade must be between 0 and 100!!");
            return;
        }

    // determain letter greade condition 
        if (grade >= 90)
        {
            letter = "an A";
        }
        else if (grade >= 80)
        {
            letter = "a B";
        }
        else if (grade >= 70)
        {
            letter = "a C";
        }
        else if (grade >= 60)
        {
            letter = "a D";
        }
        else
        {
            letter = "an F";
        }

    // pass / fail condition
        if (grade >= 70)
        {
            message = "conGratualtions You Passed Your Class!";
        }
        else
        {
            message = "Womp Wopm you failed, better luck next time";
        }

    // dertermain modifyer condition
        int lastDigit = Math.Abs(grade) % 10;
        modifier = "";

        if (grade >= 60) 
        {
            if (grade >= 93)
            {
                modifier = "";
            }
            else if (lastDigit >= 7)
            {
                modifier = "+";
            }
            else if (lastDigit < 3)
            {
                modifier = "-";
            }
            else
            {
                modifier = "";
            }
            
        }

    // Display out
        Console.WriteLine($"Your Grade is {letter}{modifier}.");
        Console.WriteLine($"{message}");
    }
}
