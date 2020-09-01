using TddNetCoreDev.Domain.Models;
using Xunit;

namespace TDDWithNetCoreXUnit.Test.ExemploFinancas
{
    public class CalculoFinanceiroTests
    {

        //[Fact]
        //public void TesteJurosCompostos_01()
        //{
        //    double valor = CalculoFinanceiro.CalcularValorComJurosCompostos(10000, 12, 2);
        //    Assert.Equal(valor, (double)12682.42);
        //}

        //[Fact]
        //public void TesteJurosCompostos_02()
        //{
        //    double valor = CalculoFinanceiro.CalcularValorComJurosCompostos(11937.28, 24, 4);
        //    Assert.Equal(valor, (double)30598.88);
        //}

        //[Fact]
        //public void TesteJurosCompostos_03()
        //{
        //    double valor = CalculoFinanceiro.CalcularValorComJurosCompostos(15000, 36, 6);
        //    Assert.Equal(valor, (double)122208.78);
        //}


        //Exemplo implementado mais refatorado com testes voltados a dados em massa.
        //Crio aqui uma Teoria e nesta teoria serão validados diferente linhas de dados.
        //Cada Inline Data é um teste diferente.
        [Theory]
        [InlineData(10000, 12, 2, 12682.42)]
        [InlineData(11937.28, 24, 4, 30598.88)]
        [InlineData(15000, 36, 6, 122208.78)]
        [InlineData(20000, 36, 6, 162945.04)]
        [InlineData(25000, 48, 6, 409846.79)]
        public void TesteJurosCompostos(double valorEmprestimo, int numMeses, double percTaxa, double valorEsperado)
        {
            double valor = CalculoFinanceiro.CalcularValorComJurosCompostos(valorEmprestimo, numMeses, percTaxa);
            Assert.Equal(valor, valorEsperado);
        }


    }
}
