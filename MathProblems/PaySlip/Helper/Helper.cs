using System;

namespace MathProblems.PaySlip
{
    public static class Helper
    {
        public static double ToDoubleValue(this string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("");

            var pieces = value.Split('%');
            if (pieces.Length > 2 || !string.IsNullOrEmpty(pieces[1]))
                throw new ArgumentException("");
            var num = decimal.Parse(pieces[0]) / 100M;

            return Convert.ToDouble(num);
        }

        public static int ToIntValue(this string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("");
            return int.Parse(value);

        }

        
    }
}
