using System;
using System.Text.RegularExpressions;

namespace cse210projects
{
    public abstract class Employee
    {
        protected string _name = string.Empty;
        protected int _idNumber;

        protected string _address = string.Empty;
        protected string _birthday = string.Empty;
        
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

        public void SetIdNumber (string idNumber)
        {
            if (!Regex.IsMatch(idNumber, @"^[A\a-Za-z]{3}\d{3}$"))
            {
                throw new ArgumentException("ID number must be in the format of three digits followed by three letters (e.g., 123abc).");
            }
            _idNumber = idNumber.ToUpper();;
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

        
        public abstract float GetPay();
    }
}