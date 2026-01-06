using System;

class Program
{
    static void Main(string[] args)

    {
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1,21);

        int guess = 0;
        while (guess != magicNumber)
        {
            Console.Write("Please enter a guess number between 1 and 20: ");
            guess = int.Parse(Console.ReadLine());

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
            }
        }

    }
}