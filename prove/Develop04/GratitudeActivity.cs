using System;
using System.Collections.Generic;

public class GratitudeActivity : Activity
{
    public GratitudeActivity(ActivityLogger logger)
        : base(
            "Gratitude",
            "This activity will help you focus on gratitude by writing down things you are thankful for.",
            logger)
    {
    }

    public override void Run()
    {
        Start();

        List<string> items = new List<string>();

        Console.WriteLine("Write one thing you are grateful for each line.");
        Console.Write("You may begin in: ");
        ShowCountdown(5);
        Console.WriteLine();
        Console.WriteLine();

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string response = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(response))
            {
                items.Add(response);
            }
        }

        Console.WriteLine();
        Console.WriteLine($"You wrote {items.Count} gratitude item(s):");
        foreach (string item in items)
        {
            Console.WriteLine($"- {item}");
        }

        LogSession(items.Count);
        End();

        Console.WriteLine("\nPress Enter to return to the menu.");
        Console.ReadLine();
    }
}
