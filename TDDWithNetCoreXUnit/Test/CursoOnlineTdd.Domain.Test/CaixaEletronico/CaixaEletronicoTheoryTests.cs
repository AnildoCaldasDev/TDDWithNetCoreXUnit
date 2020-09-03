using TddNetCoreDev.Repositorio.BLL;
using Xunit;

namespace TDDWithNetCoreXUnit.Test.CaixaEletronico
{
    public class CaixaEletronicoTheoryTests
    {
        private readonly Caixa _caixa = new Caixa();


        [Theory(DisplayName = "Saque contém número de cedulas solicitado correto")]
        [InlineData(3, 80)]
        [InlineData(3, 300)]
        [InlineData(5, 500)]
        public void Saque_contem_numero_de_cedulas_correto(int quantidadeDeCedulas, int valorDoSaque)
        {
            var resultadoCedulas = _caixa.Saque(valorDoSaque);

            Assert.Equal(resultadoCedulas.Count, quantidadeDeCedulas);
        }

    }
}
