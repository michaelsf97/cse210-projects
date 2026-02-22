using System;

namespace cse210
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