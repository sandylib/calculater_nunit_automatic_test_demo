using System;

namespace MathProblems.PaySlip
{
    public class PositiveDigiterValidator: RuleValidator
    {
        public override void Validate(Employee employee)
        {
            if (employee.AnnualSalary < 0)
                throw new ArgumentException("Annual salary can not be negative number ");
            if (Successor != null)
                Successor.Validate(employee);
        }
    }
}