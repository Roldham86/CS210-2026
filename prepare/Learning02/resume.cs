using System;
using System.Collections.Generic;
// made by W00f
public class Resume
{
// DATA //
    public string _name;
    public List<Job> _jobs = new List<Job>();

// FUNCT //
    public void Display()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs:");

        foreach (Job job in _jobs)
        {
            job.Display();
        }
    }
}

