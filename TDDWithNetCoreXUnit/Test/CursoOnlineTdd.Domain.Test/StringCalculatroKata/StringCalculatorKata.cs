using System;

namespace TDDWithNetCoreXUnit.Test.StringCalculatroKata
{
    public class StringCalculatorKata
    {
        public int Calculate(string number)
        {
            if (String.IsNullOrWhiteSpace(number))
                return 0;

            return int.Parse(number);
        }

    }
}
