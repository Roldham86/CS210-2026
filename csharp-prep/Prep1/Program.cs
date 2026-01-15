using System; 
//made by w00f
class Program
{
    static void Main(string[] args)
    {
    // prompt user for name
        Console.Write("What is your first name?");
        string First = Console.ReadLine();
        Console.Write("What is your Last name?");
        string Last = Console.ReadLine();

    // display output
        //Console.WriteLine("Hello Prep1 World!");
        Console.WriteLine($"Your name is {Last}, {First} {Last}.");
    }
}