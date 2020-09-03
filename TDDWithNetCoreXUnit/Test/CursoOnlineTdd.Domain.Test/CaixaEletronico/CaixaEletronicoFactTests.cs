using System;
using TddNetCoreDev.Repositorio.BLL;
using Xunit;

namespace TDDWithNetCoreXUnit.Test.CaixaEletronico
{
    public class CaixaEletronicoFactTests
    {

        private readonly Caixa _caixa = new Caixa();

        [Fact]
        public void Saque_Valido()
        {
            int valorDoSaque = 510;
            bool saqueValido = _caixa.ValidaCedulasDisponiveis(valorDoSaque);
            Assert.True(saqueValido);
        }

        [Fact]
        public void Deve_Gerar_Excecao()
        {
            int valorDoSaque = 5;
            Assert.Throws<Exception>(() => _caixa.Saque(valorDoSaque));
        }
    }
}
