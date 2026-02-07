using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        string choice = "";

        while (choice != "5")
        {
            Console.WriteLine();
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            choice = Console.ReadLine();

            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    string prompt = promptGenerator.GetRandomPrompt();

                    Console.WriteLine(prompt);
                    Console.Write("> ");
                    string response = Console.ReadLine();

                    Entry entry = new Entry();
                    entry._date = DateTime.Now.ToShortDateString();
                    entry._prompt = prompt;
                    entry._response = response;

                    journal.AddEntry(entry);
                    break;

                case "2":
                    journal.DisplayAll();
                    break;

                case "3":
                    Console.Write("What is the filename? ");
                    journal.LoadFromFile(Console.ReadLine());
                    break;

                case "4":
                    Console.Write("What is the filename? ");
                    journal.SaveToFile(Console.ReadLine());
                    break;

                case "5":
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.WriteLine("!!Error: Please choose a valid option (1–5)!!");
                    break;
            }
        }
    }
}