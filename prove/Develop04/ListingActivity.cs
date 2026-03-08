using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private PromptBag _promptBag;

    public ListingActivity(ActivityLogger logger, PromptBag promptBag)
        : base(
            "Listing",
            "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.",
            logger)
    {
        _promptBag = promptBag;
    }

    public override void Run()
    {
        Start();

        List<string> items = new List<string>();

        Console.WriteLine("List as many responses as you can to the following prompt:\n");
        Console.WriteLine($"--- {_promptBag.Next()} ---");
        Console.WriteLine();
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
        Console.WriteLine($"You listed {items.Count} item(s)!");

        LogSession(items.Count);
        End();

        Console.WriteLine("\nPress Enter to return to the menu.");
        Console.ReadLine();
    }
}