using System;

namespace cse210projects
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