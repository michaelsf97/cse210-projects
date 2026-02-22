using System;

partial class Employee
{
    private float salary; 

    public string name { get; set; }
    public int id { get; set; }
    public string address { get; set; }
    public string birthdate { get; set;}

    
    public virtual float CalculatePay()
    {
        return salary;

    }

    public class HourlyEmployee : Employee
    {
        public float rate = 15f;
        public float hours = 1594f;

        public override float CalculatePay()
        {
            return rate * hours;
        }
    }

    public class AnnualSalaryEmployee : Employee
    {
        public float annualSalary = 50000f;

        public override float CalculatePay()
        {
            return annualSalary / 12;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Employee.HourlyEmployee emp = new Employee.HourlyEmployee();
            Console.WriteLine(emp.CalculatePay());

            Employee.AnnualSalaryEmployee emp2 = new Employee.AnnualSalaryEmployee();
            Console.WriteLine(emp2.CalculatePay());
        }
    }

}