using System;

namespace cse210projects

{
    public class HourlyEmployee : Employee
    {
        private float _payRate = 0;
        private float _hoursWorked = 0;

        public float GetPayRate()
        {
            return _payRate;
        }

        public void SetPayRate(float payRate)
        {
            _payRate = payRate;
        }

        public float GetHoursWorked()
        {
            return _hoursWorked;
        }

        public void SetHoursWorked(float hoursWorked)
        {
            _hoursWorked = hoursWorked;

        }

        public override float GetPay()
        {
            return _hoursWorked * _payRate;
        }


    
        }
}
