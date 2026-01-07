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
        int count = 0;
        int largest = int.MinValue;

        while (number != 0)
        {
            number = int.Parse(Console.ReadLine());
            if (number != 0)
            {
                sum += number;
                count++;
                if (number > largest)
                {
                    largest = number;
                }
            }
        }

        if (count > 0)
        {
            double average = (double)sum / count;
            Console.WriteLine($"The sum is: {sum}");
            Console.WriteLine($"The average is: {average}");
            Console.WriteLine($"The largest number is: {largest}");
        }
        else
        {
            Console.WriteLine("Nothing was entered.");
        }
    }
}
