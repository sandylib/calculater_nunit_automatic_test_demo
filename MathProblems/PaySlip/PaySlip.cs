using System;

namespace MathProblems.PaySlip
{
    public class PaySlip
    {
        public PaySlip(Employee employee)
        {
            Employee = employee;
            Name = Employee.FirstName + " " + Employee.LastName;
            PayPeriod = Employee.StartDate + " - " + Employee.EndDate;

        }

        public Employee Employee { get; private set; }

        public string Name { get; private set; }

        public string PayPeriod { get; private set; }

        public double GrossIncome { get; private set; }

        public double IncomeTax { get; private set; }

        public int NetIncome { get; private set; }

        public int Super { get; private set; }

        private double InComeTaxCalculator()
        {
            double tax = 0;
            if (Employee.AnnualSalary > 0 && Employee.AnnualSalary <= 18200)
                tax = 0;
            else if (Employee.AnnualSalary > 18200 && Employee.AnnualSalary <= 37000)
                tax = ((Employee.AnnualSalary - 18200) * 0.19) / 12;
            else if (Employee.AnnualSalary > 37000 && Employee.AnnualSalary <= 80000)
                tax = (3572 + (Employee.AnnualSalary - 37000) * 0.325) / 12;
            else if (Employee.AnnualSalary > 80000 && Employee.AnnualSalary <= 180000)
                tax = (17547 + (Employee.AnnualSalary - 80000) * 0.37) / 12;
            else
                tax = (54547 + (Employee.AnnualSalary - 180000) * 0.45) / 12;
            return tax;
        }
       

        public void Build()
        {
            GrossIncome = Math.Floor((double) Employee.AnnualSalary / 12);
            IncomeTax = Math.Ceiling((double)InComeTaxCalculator());
            NetIncome = Convert.ToInt32(GrossIncome - IncomeTax);
            Super = Convert.ToInt32(GrossIncome * (Employee.SuperRate));
        }


        public override string ToString()
        {
            return Name + "," + PayPeriod + ","+ GrossIncome + "," + IncomeTax + "," + NetIncome + "," + Super;
        }
    }
}
