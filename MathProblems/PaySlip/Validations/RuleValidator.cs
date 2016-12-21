namespace MathProblems.PaySlip
{
    public abstract class RuleValidator
    {
        protected RuleValidator Successor;

        public void SetSuccessor(RuleValidator successor)
        {
            this.Successor = successor;
        }

        public abstract void Validate(Employee employee);
    }
}