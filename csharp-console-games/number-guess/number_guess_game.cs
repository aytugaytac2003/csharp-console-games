using System;

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();
        int secretNumber = random.Next(1, 101); // 1-100 arası
        int guess = 0;
        int attempts = 0;

        Console.WriteLine("Welcome to Number Guessing Game!");
        Console.WriteLine("I have selected a number between 1 and 100.");
        Console.WriteLine("Try to guess it!\n");

        while (guess != secretNumber)
        {
            Console.Write("Enter your guess: ");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out guess))
            {
                Console.WriteLine("Please enter a valid number.");
                continue;
            }

            attempts++;

            if (guess < secretNumber)
            {
                Console.WriteLine("Too low!");
            }
            else if (guess > secretNumber)
            {
                Console.WriteLine("Too high!");
            }
            else
            {
                Console.WriteLine($"\nCorrect! You found the number in {attempts} attempts.");
            }
        }

        Console.WriteLine("\nThanks for playing!");
    }
}
