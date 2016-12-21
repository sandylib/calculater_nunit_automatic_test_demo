namespace MathProblems.PaySlip
{
    public class PaySlipValidationChainManager : IResponsibilityChainManager
    {
        public RuleValidator RuleChainHeader { get; private set; }

        public PaySlipValidationChainManager(RuleValidator ruleChainHeader)
        {
            RuleChainHeader = ruleChainHeader;
        }

        public void Setup()
        {
            var daterangeValidator = new DateTimeRangerValidator();
            var percentageRangerValidator = new PercentageRangerValidator();
            RuleChainHeader.SetSuccessor(daterangeValidator);
            daterangeValidator.SetSuccessor(percentageRangerValidator);
        }
    }
}
