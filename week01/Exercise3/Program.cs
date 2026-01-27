using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 21); // random number between 1 and 20
        int guess = 0;
        int guessCount = 0;

        Console.WriteLine("Guess the magic number between 1 and 20!");
        while (guess != magicNumber)
        {
            Console.Write("What is your guess? ");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                Console.WriteLine("You quit the game.");
                return;
            }

            if (int.TryParse(input, out guess))
            {
                guessCount++;
                if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                    Console.WriteLine($"You have guessed {guessCount} times.");
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid number or type 'quit' to exit.");
            }
        }

        Console.WriteLine("Thanks for playing!!");
    }
}