using System;

class Program
{
    static void Main(string[] args)
    {
        // Exceeding requirements:
        // 1. Added a fourth activity: GratitudeActivity
        // 2. Added a log file to track completed sessions
        // 3. Added menu statistics from the log
        // 4. Added PromptBag so prompts/questions do not repeat until all have been used

        ActivityLogger logger = new ActivityLogger("log.txt");

        PromptBag reflectionPrompts = new PromptBag(new string[]
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        });

        PromptBag reflectionQuestions = new PromptBag(new string[]
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        });

        PromptBag listingPrompts = new PromptBag(new string[]
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        });

        bool running = true;

        while (running)
        {
            ActivityStats stats = logger.GetStats();

            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflection activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Start gratitude activity");
            Console.WriteLine("  5. Quit");
            Console.WriteLine();

            Console.WriteLine("Session Stats:");
            Console.WriteLine($"  Total Sessions: {stats.TotalSessions}");
            Console.WriteLine($"  Total Mindful Time: {stats.TotalSeconds / 60} minute(s) {stats.TotalSeconds % 60} second(s)");
            Console.WriteLine($"  Breathing: {stats.GetCount("Breathing")}");
            Console.WriteLine($"  Reflection: {stats.GetCount("Reflection")}");
            Console.WriteLine($"  Listing: {stats.GetCount("Listing")}");
            Console.WriteLine($"  Gratitude: {stats.GetCount("Gratitude")}");
            Console.WriteLine();

            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            Activity activity = null;

            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity(logger);
                    break;
                case "2":
                    activity = new ReflectionActivity(logger, reflectionPrompts, reflectionQuestions);
                    break;
                case "3":
                    activity = new ListingActivity(logger, listingPrompts);
                    break;
                case "4":
                    activity = new GratitudeActivity(logger);
                    break;
                case "5":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Press Enter to continue.");
                    Console.ReadLine();
                    break;
            }

            if (activity != null)
            {
                activity.Run();
            }
        }
    }
}