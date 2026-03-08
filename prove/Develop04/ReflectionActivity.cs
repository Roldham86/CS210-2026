using System;

public class ReflectionActivity : Activity
{
    private PromptBag _promptBag;
    private PromptBag _questionBag;

    public ReflectionActivity(ActivityLogger logger, PromptBag promptBag, PromptBag questionBag)
        : base(
            "Reflection",
            "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.",
            logger)
    {
        _promptBag = promptBag;
        _questionBag = questionBag;
    }

    public override void Run()
    {
        Start();

        Console.WriteLine("Consider the following prompt:\n");
        Console.WriteLine($"--- {_promptBag.Next()} ---");
        Console.WriteLine();
        Console.Write("When you have something in mind, press Enter to continue.");
        Console.ReadLine();

        Console.WriteLine();
        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
        Console.Write("You may begin in: ");
        ShowCountdown(5);
        Console.Clear();

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            Console.WriteLine($"> {_questionBag.Next()}");
            ShowSpinner(5);
            Console.WriteLine();
            Console.WriteLine();
        }

        LogSession();
        End();

        Console.WriteLine("\nPress Enter to return to the menu.");
        Console.ReadLine();
    }
}