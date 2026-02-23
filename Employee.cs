using System;

namespace cse210projects
{
    public class Employee
    {
        protected string _name;
        protected int _idNumber;

        protected string _address;
        protected string _birthday;

        protected float _payRate;
        
            public string GetName()
            {
                return _name;
            }

            public void SetName(string name)
        {
            _name = name;
        }

        public int GetIdNumber()
        {
            return _idNumber;
        }

        public void SetIdNumber (int idNumber)
        {
            _idNumber = idNumber;
        }

        public string GetAddress()
        {
            return _address;
        }

        public void SetAddress(string address)
        {
            _address = address;
        }

        public string GetBirthday()
        {
            return _birthday;
        }

        public void SetBirthday (string birthday)

        {
            _birthday = birthday;
        }

        
        public virtual float GetPay()
        {
            return -1;
        }
    }
}