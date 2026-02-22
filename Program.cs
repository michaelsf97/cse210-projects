using System;

partial class Employee
{
    private float salary; 
    
    public virtual float CalculatePay()
    {
        return salary;

    }

    public class HourlyEmployee : Employee
    {
        public float rate = 9f;
        public float hours = 100f;

        public override float CalculatePay()
        {
            return rate * hours;
        }
    }

}