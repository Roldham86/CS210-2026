using System;
// made by w00f
class Program
{
    static void Main(string[] args)
    {
    // declare initial variables
        int newnum = 99;
        float sum = 0;
        float avg = 0;
        int lrg = 0;
        int sml = int.MaxValue;
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

    // retreve numbers from user 1
        while (newnum != 0)
        {
            Console.Write("Enter number: ");
            string newnumStr = Console.ReadLine(); 
            newnum = int.Parse(newnumStr); // convert grade to int
            numbers.Add(newnum);
        }
    // loop through the list to...    
        for (int i = 0; i < numbers.Count; i++)
        { 
        // create the sum
            sum += numbers[i]; 
        // find the largest number 
            if (numbers[i] > lrg)
            {
                lrg = numbers[i];  
            }
        // find the smallest non-negitive number
            if (numbers[i] < sml && numbers[i] > 0)
            {
                sml = numbers[i];
            }
        }
    // creat the advrage 
        avg = sum / (numbers.Count - 1);
    // sort the numbers    
        numbers.Sort();
    // display the results 
        Console.WriteLine();
        Console.WriteLine("-------------------");
        Console.WriteLine("The Sum is:      " + sum );
        Console.WriteLine("The advrage is:  " + avg );
        Console.WriteLine("The largest is:  " + lrg );
        Console.WriteLine("The smallest positive is: " + sml );
        Console.Write("The sorted list is: ");
        for (int i = 0; i < numbers.Count; i++)
        {
            Console.Write(numbers[i] + ", ");
        }
    }
}