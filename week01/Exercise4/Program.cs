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
        int smallestPositive = int.MaxValue;

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
                    int largest = int.MinValue;
                    int smallestPositive = int.MaxValue;
                if (number > 0 && number < smallestPositive)
                {
                    smallestPositive = number;
                }
            }

        }
        }

        if (count > 0)
                if (smallestPositive != int.MaxValue)
                {
                    Console.WriteLine($"The smallest positive number is: {smallestPositive}");
                }
                else
                {
                    Console.WriteLine("No positive numbers were entered.");
                }
        {
            double average = (double)sum / count;
            Console.WriteLine($"The sum is: {sum}");
            Console.WriteLine($"The average is: {average}");
            Console.WriteLine($"The largest number is: {largest}");
        }
        else
        {
                        if (smallestPositive != int.MaxValue)
                        {
                            Console.WriteLine($"The smallest positive number is: {smallestPositive}");
                        }
                        else
                        {
                         Console.WriteLine("No positive numbers were entered.");
                        }
            Console.WriteLine("Nothing was entered.");
        }
    }
}
