using Moq;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;
using TddNetCoreDev.Repositorio.Interfaces;
using Xunit;

namespace TDDWithNetCoreXUnit.Test.CaixaEletronico
{
    public class CaixaEletronicoMoqTests
    {

        [Fact(DisplayName = "Mock saque com sucesso NSubstitute")]
        public void Saque_Com_Sucesso_NSub()
        {
            var caixa = Substitute.For<ICaixa>();//criei o objeto mock pra interface ICaixa.

            int valorDoSaque = 50;
            caixa.Saque(valorDoSaque).Returns(new int[] { });//efetua a simulação do saque e assegura que o retorno é uma lista de int
            caixa.Received(1);//confirmar que metodo foi executado uma unica vez;

        }


        [Fact(DisplayName = "Mock saque com sucesso Moq")]
        public void Saque_Com_Sucesso_Moq()
        {
            var caixaMoq = new Mock<ICaixa>();
            int valorDoSaque = 50;
            caixaMoq.Object.Saque(valorDoSaque);
            caixaMoq.Verify(r => r.Saque(valorDoSaque), Times.Once);


        }



    }
}
