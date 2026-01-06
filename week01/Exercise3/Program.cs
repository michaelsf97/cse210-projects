using System;

class Program
{
    static void Main(string[] args)

    {
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1,21);

        int guess = 0;
        int guessCount = 0;
        while (guess != magicNumber)
        
        {
            Console.Write("Please enter a guess number between 1 and 20: ");
            guess = int.Parse(Console.ReadLine());

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

            Console.WriteLine("Would you like to play again? (y/n): ");
            string playAgain = Console.ReadLine();

            Console.WriteLine("Thanks for playing!!");


        }

    }
}