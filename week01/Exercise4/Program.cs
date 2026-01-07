using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished: ");

        int number = -1;
        int sum = 0;

        while (number != 0)
        {
            number = int.Parse(Console.ReadLine());
            if (number != 0)
            {
                sum += number;
            }
        }

        Console.WriteLine($"The sum is: {sum}");
    }
}