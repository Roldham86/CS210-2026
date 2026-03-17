using System;
using System.Collections.Generic;
// Made by W00F
// Exceeding requirements:
// Added a level system based on total score.
// Every 1000 points increases the player's level,
// adding a gamification element to encourage progress.
public class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        int choice = 0;
    // Main menu loop.
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

            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 6)
            {
                Console.Write("Enter a valid menu choice (1-6): ");
            }

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
            }
        }
    }

// Handles creating a new goal based on the user's selected goal type.
    static void CreateGoalMenu(GoalManager manager)
    {
        Console.WriteLine("\nThe types of Goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
    // safely retrieve data from user 
        int goalType;
        while (!int.TryParse(Console.ReadLine(), out goalType) || goalType < 1 || goalType > 3)
        {
            Console.Write("Enter a valid goal type (1-3): ");
        }

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine() ?? "";

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine() ?? "";

        Console.Write("What is the amount of points associated with this goal? ");
        int points;
        while (!int.TryParse(Console.ReadLine(), out points) || points < 0)
        {
            Console.Write("Enter a valid non-negative number: ");
        }

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
                int targetAmount;
                while (!int.TryParse(Console.ReadLine(), out targetAmount) || targetAmount <= 0)
                {
                    Console.Write("Enter a valid number greater than 0: ");
                }

                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonus;
                while (!int.TryParse(Console.ReadLine(), out bonus) || bonus < 0)
                {
                    Console.Write("Enter a valid non-negative number: ");
                }

                manager.AddGoal(new ChecklistGoal(name, description, points, targetAmount, bonus));
                break;
        }
    }

// Lets the user choose which goal to record progress on.
    static void RecordEventMenu(GoalManager manager)
    {
        List<Goal> goals = manager.GetGoals();

        if (goals.Count == 0)
        {
            Console.WriteLine("\nNo goals available to record.");
            return;
        }

        Console.WriteLine("\nThe goals are:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].GetDetailsString()}");
        }

        Console.Write("Which goal did you accomplish? ");
        int goalNumber;
        while (!int.TryParse(Console.ReadLine(), out goalNumber) || goalNumber < 1 || goalNumber > goals.Count)
        {
            Console.Write($"Enter a valid goal number (1-{goals.Count}): ");
        }

        int pointsEarned = manager.RecordEvent(goalNumber - 1);

        if (pointsEarned == 0)
        {
            Console.WriteLine("That goal is already complete.");
        }
        else
        {
            Console.WriteLine($"Congratulations! You earned {pointsEarned} points!");
        }
    }
}