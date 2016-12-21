using System;

namespace MathProblems.PaySlip
{
    public class DateTimeRangerValidator : RuleValidator
    {
        public override void Validate(Employee employee)
        {

            if (string.IsNullOrEmpty(employee.StartDate) || string.IsNullOrEmpty(employee.EndDate))
                throw new ArgumentNullException("");

            if(employee.StartDate.Equals(employee.EndDate))
                throw new ArgumentOutOfRangeException("");


            Successor?.Validate(employee);
        }
    }
}