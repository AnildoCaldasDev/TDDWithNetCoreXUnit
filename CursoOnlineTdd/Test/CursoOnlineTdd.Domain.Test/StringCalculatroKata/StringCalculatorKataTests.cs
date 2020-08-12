using Shouldly;
using Xunit;

namespace TDDWithNetCoreXUnit.Test.StringCalculatroKata
{
    public class StringCalculatorKataTests
    {

        private readonly StringCalculatorKata _stringCalculatorKata;

        public StringCalculatorKataTests()
        {
            _stringCalculatorKata = new StringCalculatorKata();
        }


        [Fact]
        public void ShoudreturnZeroToEmptyString()
        {
            var result = _stringCalculatorKata.Calculate("");
            result.ShouldBe(0);
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(9, 9)]
        [InlineData(155, 155)]
        public void ShouldReturnExpectedNumbersInloineTheory(int number, int expectedResult)
        {
            var result = _stringCalculatorKata.Calculate(number.ToString());
            result.ShouldBe(expectedResult);
        }
    }
}
