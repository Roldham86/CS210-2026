using System;
using System.Threading;

public abstract class Activity
{
    private string _name;
    private string _description;
    private int _durationSeconds;
    private ActivityLogger _logger;

    protected Activity(string name, string description, ActivityLogger logger)
    {
        _name = name;
        _description = description;
        _logger = logger;
    }

    public void Start()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name} Activity.\n");
        Console.WriteLine(_description);
        Console.WriteLine();

        _durationSeconds = ReadPositiveInt("How long, in seconds, would you like for your session? ");

        Console.WriteLine();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
        Console.Clear();
    }

    public void End()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!!");
        ShowSpinner(3);
        Console.WriteLine();
        Console.WriteLine($"You have completed another {_durationSeconds} seconds of the {_name} Activity.");
        ShowSpinner(3);
    }

    protected int GetDuration()
    {
        return _durationSeconds;
    }

    protected string GetName()
    {
        return _name;
    }

    protected void LogSession(int? itemCount = null)
    {
        ActivityLogEntry entry = new ActivityLogEntry(
            DateTime.Now,
            _name,
            _durationSeconds,
            itemCount
        );

        _logger.Append(entry);
    }

    protected void ShowSpinner(int seconds)
    {
        string[] spinner = { "|", "/", "-", "\\" };
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int i = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write(spinner[i]);
            Thread.Sleep(200);
            Console.Write("\b \b");
            i = (i + 1) % spinner.Length;
        }
    }

    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);

            if (i >= 10)
            {
                Console.Write("\b\b  \b\b");
            }
            else
            {
                Console.Write("\b \b");
            }
        }
    }

    private int ReadPositiveInt(string prompt)
    {
        int value;
        bool valid = false;

        do
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            valid = int.TryParse(input, out value) && value > 0;

            if (!valid)
            {
                Console.WriteLine("Please enter a whole number greater than 0.");
            }
        } while (!valid);

        return value;
    }

    public abstract void Run();
}