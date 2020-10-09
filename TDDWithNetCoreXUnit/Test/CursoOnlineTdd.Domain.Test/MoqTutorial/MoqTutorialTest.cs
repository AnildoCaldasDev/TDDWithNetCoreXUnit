using Moq;
using System.Runtime.InteropServices.ComTypes;
using Xunit;

namespace TDDWithNetCoreXUnit.Test.MoqTutorial
{
    public class MoqTutorialTest
    {

        [Fact]
        public void GetPrefixedValue_Mock()
        {
            var mock = new Mock<IMockTarget>();
            mock.SetupGet(x => x.PropertyToMock).Returns("FixedValue");

            var classToTest = new ClassToTest();

            var actualValue = classToTest.GetPrefixedValue(mock.Object);

            Assert.Equal("Prefixed: FixedValue", actualValue);
            mock.VerifyGet(x => x.PropertyToMock);
        }


        [Fact]
        public void GetSomaValoresCalculator_Mock()
        {
            int x = 10;
            int y = 20;
            int somaResult = 30;

            var mock = new Mock<IMockCalculator>();
            mock.Setup(x => x.SomaDoisNumeros(10,20)).Returns(30);

            var calcTest = new CalculatorTest(mock.Object);

            int result = calcTest.SomaDoisNumeros(x, y);

            Assert.Equal(somaResult, result);
            mock.Verify(x => x.SomaDoisNumeros(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
        }
    }


    public class ClassToTest
    {
        public string GetPrefixedValue(IMockTarget provider)
        {
            return "Prefixed: " + provider.PropertyToMock;
        }
    }

    public class CalculatorTest : IMockCalculator
    {
        private readonly IMockCalculator _mock;

        public CalculatorTest(IMockCalculator mock)
        {
            _mock = mock;
        }


        public int SomaDoisNumeros(int x, int y)
        {

            return _mock.SomaDoisNumeros(x, y);

         //   return x + y;
        }
    }


    public interface IMockTarget
    {
        public string PropertyToMock { get; set; }
    }

    public interface IMockCalculator
    {    
        public int SomaDoisNumeros(int x, int y);
    }

}
