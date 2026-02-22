using System;

namespace cse210_demo

{
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
