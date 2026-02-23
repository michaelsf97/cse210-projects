using System;

namespace cse210projects
{
	public class SalaryEmployee : Employee
	{
		private float _annualSalary = 0;

		public float GetAnnualSalary()
		{
			return _annualSalary;
		}

		public void SetAnnualSalary(float annualSalary)
		{
			_annualSalary = annualSalary;
		}

		public override float GetPay()
		{
			return _salary / 12;
		}

}
}