using Shouldly;
using Xunit;

namespace TDDWithNetCoreXUnit.Test.FisrtLessonTDD
{
    public class FizzBuzzDetectorTests
    {
        [Fact]
        public void PrintOne()
        {
            var result = FizzBuzzDetector.IdentifyFizzBuzz(1);
            result.ShouldBe("1");
        }

        [Fact]
        public void PrintTwo()
        {
            var result = FizzBuzzDetector.IdentifyFizzBuzz(2);
            result.ShouldBe("2");
        }

        [Fact]
        public void PrintFour()
        {
            var result = FizzBuzzDetector.IdentifyFizzBuzz(4);
            result.ShouldBe("4");
        }


        [Theory]
        [InlineData(1, "1")]
        [InlineData(2, "2")]
        [InlineData(4, "4")]
        public void PrintNumbers(int number, string expected)
        {
            var result = FizzBuzzDetector.IdentifyFizzBuzz(number);
            result.ShouldBe(expected);
        }


        //[Fact]
        //public void PrintFizz()
        //{
        //    var result = FizzBuzzDetector.IdentifyFizzBuzz(3);
        //    result.ShouldBe("Fizz");
        //}

        [Fact]
        public void PrintBuzz()
        {
            var result = FizzBuzzDetector.IdentifyFizzBuzz(5);
            result.ShouldBe("Buzz");
        }

        [Theory]
        [InlineData(3, "Fizz")]
        [InlineData(6, "Fizz")]
        [InlineData(9, "Fizz")]
        public void PrintFizz(int number, string expected)
        {
            var result = FizzBuzzDetector.IdentifyFizzBuzz(number);
            result.ShouldBe(expected);
        }


        [Theory]
        [InlineData(15, "FizzBuzz")]
        [InlineData(45, "FizzBuzz")]
        [InlineData(60, "FizzBuzz")]
        public void PrintFizzBuzzTheory(int number, string expected)
        {
            var result = FizzBuzzDetector.IdentifyFizzBuzz(number);
            result.ShouldBe(expected);
        }

    }
}
