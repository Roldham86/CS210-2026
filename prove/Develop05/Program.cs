using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();

        int choice = 0;

        while (choice != 6)
        {
            manager.DisplayPlayerInfo();

            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Select a choice from the menu: ");

            string input = Console.ReadLine() ?? "";
            int.TryParse(input, out choice);

            switch (choice)
            {
                case 1:
                    CreateGoalMenu(manager);
                    break;

                case 2:
                    manager.ListGoalDetails();
                    break;

                case 3:
                    Console.Write("Enter filename to save to: ");
                    string saveFile = Console.ReadLine() ?? "";
                    manager.SaveGoals(saveFile);
                    Console.WriteLine("Goals saved successfully.");
                    break;

                case 4:
                    Console.Write("Enter filename to load from: ");
                    string loadFile = Console.ReadLine() ?? "";
                    manager.LoadGoals(loadFile);
                    Console.WriteLine("Goals loaded successfully.");
                    break;

                case 5:
                    RecordEventMenu(manager);
                    break;

                case 6:
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void CreateGoalMenu(GoalManager manager)
    {
        Console.WriteLine("\nThe types of Goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");

        string input = Console.ReadLine() ?? "";
        int goalType;
        int.TryParse(input, out goalType);

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine() ?? "";

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine() ?? "";

        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine() ?? "0");

        switch (goalType)
        {
            case 1:
                manager.AddGoal(new SimpleGoal(name, description, points));
                break;

            case 2:
                manager.AddGoal(new EternalGoal(name, description, points));
                break;

            case 3:
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int targetAmount = int.Parse(Console.ReadLine() ?? "0");

                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonus = int.Parse(Console.ReadLine() ?? "0");

                manager.AddGoal(new ChecklistGoal(name, description, points, targetAmount, bonus));
                break;

            default:
                Console.WriteLine("Invalid goal type.");
                break;
        }
    }

    static void RecordEventMenu(GoalManager manager)
    {
        if (manager.GetGoals().Count == 0)
        {
            Console.WriteLine("\nNo goals available to record.");
            return;
        }

        Console.WriteLine("\nThe goals are:");
        for (int i = 0; i < manager.GetGoals().Count; i++)
        {
            Console.WriteLine($"{i + 1}. {manager.GetGoals()[i].GetDetailsString()}");
        }

        Console.Write("Which goal did you accomplish? ");
        int goalNumber = int.Parse(Console.ReadLine() ?? "0");

        int pointsEarned = manager.RecordEvent(goalNumber - 1);

        if (pointsEarned == -1)
        {
            Console.WriteLine("Invalid goal selection.");
        }
        else if (pointsEarned == 0)
        {
            Console.WriteLine("That goal is already complete or no points were awarded.");
        }
        else
        {
            Console.WriteLine($"Congratulations! You earned {pointsEarned} points!");
        }
    }
}