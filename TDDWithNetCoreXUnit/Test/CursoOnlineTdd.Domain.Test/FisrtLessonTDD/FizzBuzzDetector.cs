using System;
using System.Collections.Generic;
using System.Text;

namespace TDDWithNetCoreXUnit.Test.FisrtLessonTDD
{
    public class FizzBuzzDetector
    {
        public static string IdentifyFizzBuzz(int i)
        {
            if (i % 15 == 0)
                return "FizzBuzz";

            if (i % 5 == 0)
                return "Buzz";

            return i % 3 == 0 ? "Fizz" : i.ToString();
        }
    }
}
