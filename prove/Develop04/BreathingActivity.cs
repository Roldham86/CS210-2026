using System;

public class BreathingActivity : Activity
{
    public BreathingActivity(ActivityLogger logger)
        : base(
            "Breathing",
            "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.",
            logger)
    {
    }

    public override void Run()
    {
        Start();

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            Console.Write("\nBreathe in... ");
            ShowCountdown(4);
            Console.WriteLine();

            if (DateTime.Now >= endTime)
            {
                break;
            }

            Console.Write("Breathe out... ");
            ShowCountdown(4);
            Console.WriteLine();
        }

        LogSession();
        End();

        Console.WriteLine("\nPress Enter to return to the menu.");
        Console.ReadLine();
    }
}