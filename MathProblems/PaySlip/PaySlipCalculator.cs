using System;
using System.Collections.Generic;

namespace MathProblems.PaySlip
{
    public class PaySlipCalculator
    {
        private readonly List<Employee> _employees;
        private readonly PaySlipValidationChainManager _validationChainManager;
        private readonly PositiveDigiterValidator _validationChainHeader;

        public PaySlipCalculator()
        {
            _employees = new List<Employee>();
            _validationChainHeader = new PositiveDigiterValidator();
            _validationChainManager = new PaySlipValidationChainManager(_validationChainHeader);
            _validationChainManager.Setup();
        }

        public List<string> Convert(List<string> employeeInfos)
        {
            try
            {
                //conver string to employee object
                foreach (var employeeInfo in employeeInfos)
                {
                    StringToEmployee(employeeInfo);
                }

                //validate it
                foreach (var employee in _employees)
                {
                    _validationChainHeader.Validate(employee);
                }

                return PaySlipFormat();

            }
            catch (ArgumentException e)
            {
                throw;
            }
        }

        private List<string> PaySlipFormat()
        {
            var result = new List<string>();
            foreach (var employee in _employees)
            {
                var payslip = new PaySlip(employee);
                        payslip.Build();

             
                result.Add(payslip.ToString());
            }
            return result;
        }

        private void StringToEmployee(string employeeInfo)
        {
            string[] infoList = employeeInfo.Split(',');

            var dateRange = infoList[4].Split('-');
            var result = new Employee(infoList[0], infoList[1], infoList[2].ToIntValue(), infoList[3].ToDoubleValue(),
                dateRange[0].Trim(), dateRange[1].Trim());

            _employees.Add(result);
        }
    }
}
