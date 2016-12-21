using System.Collections.Generic;

namespace MathProblems.PaySlip
{
    public interface IResultFormatter
    {
        void Format(IEnumerable<string> input);
        List<string> ReadConvert(string filePath);
    }
}