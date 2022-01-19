using Moq;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using Xunit;

namespace TDDWithNetCoreXUnit.Test.MoqTutorial
{

    public class MoqTutorialTest
    {
        [Fact]
        public void Somar_Dois_Numeros()
        {
            //Arrange
            Moq.Mock<ICalculadora> mock = new Mock<ICalculadora>();
            mock.Setup(x => x.Calcular(It.IsAny<string>(), It.IsAny<double>(), It.IsAny<double>())).Returns(("somar", 7.7));
            MaquinaCalculadoraAppService maqCalcServiceApp = new MaquinaCalculadoraAppService(mock.Object);

            //assert
            (string operacao, double resultado) op = maqCalcServiceApp.Calcular("somar", 3.2, 4.5);
            
            //act
            Assert.Equal("somar", op.operacao);
            Assert.Equal(7.7, op.resultado);
            mock.Verify(x => x.Calcular(It.IsAny<string>(), It.IsAny<double>(), It.IsAny<double>()), Times.Once);
        }
    }


    public class MaquinaCalculadoraAppService
    {
        private ICalculadora _calc;

        public MaquinaCalculadoraAppService() : this(new CalculadoraServiceDomain()) { }

        public MaquinaCalculadoraAppService(ICalculadora calc)
        {
            this._calc = calc;
        }

        public (string operacao, double resultado) Calcular(string operacao, double a, double b)
        {
            return _calc.Calcular(operacao, a, b);
        }
    }


    public interface ICalculadora
    {
        (string operacao, double resultado) Calcular(string operacao, double a, double b);
        List<string> GetListaOperacaoPorCodigoDeNivel(int level);
    }

    public class CalculadoraServiceDomain : ICalculadora
    {
        public (string operacao, double resultado) Calcular(string operacao, double a, double b)
        {
            (string operacao, double resultado) resultadoOperacao;
            double c;
            switch (operacao)
            {
                case "somar":
                    c = a + b;
                    break;
                case "subtrair":
                    c = a - b;
                    break;
                case "multiplicar":
                    c = a * b;
                    break;
                case "dividir":
                    c = Math.Round(a / b, 2);
                    break;
                default:
                    c = a + b;
                    break;
            }

            resultadoOperacao = (operacao, c);
            return resultadoOperacao;
        }

        public List<string> GetListaOperacaoPorCodigoDeNivel(int level)
        {
            List<string> listaniveis = new List<string>();





        }
    }




    //public class MoqTutorialTest
    //{
    //    [Fact]
    //    public void GetPrefixedValue_Mock()
    //    {
    //        var mock = new Mock<IMockTarget>();
    //        mock.SetupGet(x => x.PropertyToMock).Returns("FixedValue");

    //        var classToTest = new ClassToTest();

    //        var actualValue = classToTest.GetPrefixedValue(mock.Object);

    //        Assert.Equal("Prefixed: FixedValue", actualValue);
    //        mock.VerifyGet(x => x.PropertyToMock);
    //    }        
    //}

    //public class ClassToTest
    //{
    //    public string GetPrefixedValue(IMockTarget provider)
    //    {
    //        return "Prefixed: " + provider.PropertyToMock;
    //    }
    //}
    //public interface IMockTarget
    //{
    //    public string PropertyToMock { get; set; }
    //}
}
