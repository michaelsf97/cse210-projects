using System;

namespace cse210projects
{
    class Program
    {
        static void Main(string[] args)
        {
            HourlyEmployee hEmployee = new HourlyEmployee();
            hEmployee.SetName("John");
            hEmployee.SetIdNumber("123abc");
            hEmployee.SetAddress("123 Main Street");
            hEmployee.SetBirthday("08/04/1997");
            hEmployee.SetPayRate(15);
            hEmployee.SetHoursWorked(35);

            SalaryEmployee sEmployee = new SalaryEmployee();
            sEmployee.SetName("Peter");
            sEmployee.SetIdNumber("456def");
            sEmployee.SetAddress("456 Elm Street");
            sEmployee.SetBirthday("08/04/1997");
            sEmployee.SetAnnualSalary(60000);

            DisplayEmployeeInformation(hEmployee);
            DisplayEmployeeInformation(sEmployee);

            List<Employee> employees = new List<Employee>();
            employees.Add(hEmployee);
            employees.Add(sEmployee);

            foreach(Employee emp in employees)
            {
                DisplayEmployeeInformation(emp);
            }
        }

        public static void DisplayEmployeeInformation(Employee employee)
        {

            float pay = employee.GetPay();
            Console.WriteLine($"Name: {employee.GetName()}");
            Console.WriteLine($"ID Number: {employee.GetIdNumber()}");
            Console.WriteLine($"Address: {employee.GetAddress()}");
            Console.WriteLine($"Birthday: {employee.GetBirthday()}");
            Console.WriteLine($"Pay: ${pay}");
            Console.WriteLine();

        }
    }
}