using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the program!");
        string name = PromptUserName();
        int number = PromptFavoriteNumber();
        int square = SquareNumber(number);
        Console.WriteLine($"{name}, the square of your favorite number is: {square}");
    }

    static string PromptUserName()
    {
        Console.WriteLine("Please enter your name: ");
        return Console.ReadLine();
    }

    static int PromptFavoriteNumber()
    {
        Console.WriteLine("Please enter your favorite number: ");
        string input = Console.ReadLine();
        int number = int.Parse(input);
        return number;
    }

    static int SquareNumber(int number)
    {
        return number * number;
    }
}