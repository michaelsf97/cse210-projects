using System;

namespace cse210_demo
{
    class Program
    {
        static void Main(string[] args)
        {
            HourlyEmployee emp = new HourlyEmployee();
            float pay = emp.CalculatePay();
            Console.WriteLine($"Pay: {pay}");
        }
    }
}