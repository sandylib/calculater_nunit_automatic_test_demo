using System;

namespace MathProblems.PaySlip
{
    public class PercentageRangerValidator : RuleValidator
    {
        public override void Validate(Employee employee)
        {
            if (employee.SuperRate < 0 || employee.SuperRate > 0.5)
                throw new ArgumentOutOfRangeException("");

            Successor?.Validate(employee);
        }
    }
}