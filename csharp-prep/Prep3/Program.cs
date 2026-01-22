using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
// made by w00f
class Program
{
    static void Main(string[] args)
    {
    // Initialize repeat character to 'Y' to start the game
        char repeat = 'Y';
    // Loop until the user chooses 'n'
        while(char.ToLower(repeat) != 'n')
        {
            int guess = 0; // Initialize guess variable
        // Create a random number generator
            Random randomGenerator = new Random();
            int number = randomGenerator.Next(1, 101); // Generate a random number between 1 and 10
            Console.WriteLine(number); // Print the random number //DEbug//
        // Initialize a list to store the user's guesses
            List<int> guesses = new List<int>();
        // Loop until the user guesses the correct number
            while (guess != number)
            {
                Console.Write("please guess a number: "); 
                string guessStr = Console.ReadLine(); // Read user input
            // Convert input to an integer
                if (!int.TryParse(guessStr, out guess))
                {
                    Console.WriteLine("!!Error: please enter a whole number!!");
                    continue;
                }
                guesses.Add(guess); // Add guess to the list
            // Provide feedback on the user's guess
                if (guess > number)
                {
                    Console.WriteLine("too high");
                }
                else if (guess < number)
                {
                    Console.WriteLine("too low");
                }
            }
        // If the user guesses the correct number
            if (guess == number)
            {
                int attempt = guesses.Count; // Get the number of attempts
                Console.WriteLine("you guessed it!!");
                Console.WriteLine("It took you " + attempt + " guesses to get the right number");
                Console.Write("your guesses were: ");
            // Print all the user's guesses
                foreach (int num in guesses) 
                { 
                    Console.Write(num + ", "); 
                }
                Console.WriteLine();
            // Ask the user if they want to play again
                Console.Write("Again(y/n): ");
                string rep = Console.ReadLine();
                repeat = string.IsNullOrEmpty(rep) ? 'n' : rep[0];

            }
        }
    }
}