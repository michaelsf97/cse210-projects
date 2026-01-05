using System;
using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter Number Note:");
        string valueFromUser = Console.ReadLine();

        int number = int.Parse(valueFromUser);
        string Note;

        if (number >= 95)
        {
            Note = "A";
        }
        else if (number >= 90)
        {
            Note = "A-";
        }
        else if (number >= 85)
        {
            Note = "B+";
        }
        else if (number >= 80)
        {
            Note = "B";
        }
        else if (number >= 75)
        {
            Note = "B-";
        }
        else if (number >= 70)
        {
            Note = "C+";
        }
        else if (number >= 65)
        {
            Note = "C";
        }
        else if (number >= 60)
        {
            Note = "D";
        }
        else
        {
            Note = "F";
        }

        Console.WriteLine($"Your Note is: {Note}");

        if (number >= 70)
        {
            Console.WriteLine("Congratulations you passed!");
        }
        else
        {
            Console.WriteLine("Try again later, good luck next time!!!");
        }
    }
}
