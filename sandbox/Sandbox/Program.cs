using System;
using System.Collections.Concurrent;

public class Program
{
    public static void Main(string[] args)
    {
        Book b2 = new Book("BoxcChild", 101);
        Book b1 = new Book("charweb", 101, true);
        

        Console.WriteLine(b2.getSummery());
        Console.WriteLine(b1.getSummery());
    }

    
}

