using System;
using System.Runtime.CompilerServices;

namespace cse210_demo

{
    public class SalaryEmployee : Employee

    {
        private float _salary = 0;

        public float GetSalary()
        {
            return _salary;
        }

        public void SetSalary(float salary)
        {
            _salary = salary;
        }

        public override float CalculatePay()
        {
            return _salary;
        }
    }
}