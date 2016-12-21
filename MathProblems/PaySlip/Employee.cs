namespace MathProblems.PaySlip
{
    public class Employee
    {
        public Employee() : this("", "", 0, 0, "", "")
        {
            
        }

        public Employee(string firstName, string lastName, int annualSalary, double superRate, string startDate, string endDate)
        {
            FirstName = firstName;
            LastName = lastName;
            AnnualSalary = annualSalary;
            SuperRate = superRate;
            EndDate = endDate;
            StartDate = startDate;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int AnnualSalary { get; private set; }
        public double SuperRate {get; private set; }
        public string StartDate { get; private set; }
        public string EndDate { get; private set; }
    }
}
