using System;
// made by w00f
class Program
{
    static void Main(string[] args)
    {
    // Calling functions
        DisplayWelcome();
        string name = PromptUserName();
        int number = PromptUserNumber();
        int birthYear;
        PromtUserBirthYear(out birthYear);
        int squaredNumber = SquareNumber(number);
        DisplayResult(name, squaredNumber, birthYear);
    }


//display the welcome message
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }
//prompt the user for their name and return it
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }
// prompt the user for their birth year (out parameter)
    static void PromtUserBirthYear(out int birthYear)
    {
        Console.Write("Please enter the year you were born: ");
        birthYear = int.Parse(Console.ReadLine());
    }
//prompt the user for their favorite number and return it
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        return int.Parse(Console.ReadLine());
    }
//square a number and return the result
    static int SquareNumber(int number)
    {
        return number * number;
    }
// display the user's name, squared number, and age
    static void DisplayResult(string name, int squaredNumber, int birthYear)
    {
        int currentYear = DateTime.Now.Year;
        int age = currentYear - birthYear;

        Console.WriteLine($"{name}, the square of your number is {squaredNumber}.");
        Console.WriteLine($"{name}, you will turn {age} this year.");
    }

}