using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TddNetCoreDev.Repositorio.Interfaces;
using TDDWithNetCoreXUnit.IntegrationTests.Fixtures;
using Xunit;

namespace TDDWithNetCoreXUnit.IntegrationTests.Scenarios
{
    public class CaixaEletronicoFixtureIntegrationTests : IClassFixture<IntegrationTestFixture>
    {
        private ICaixa _caixa;

        public CaixaEletronicoFixtureIntegrationTests(IntegrationTestFixture fixture)
        {
            _caixa = fixture.ServiceProvider.GetRequiredService<ICaixa>();
        }

        [Fact]
        [Trait("Operacao", "Saque Menor Numero notas")]
        public void SaqueContemMenorNumeroDeCedulas()
        {
            int quantidadeDeCedulas = 3;
            int valorDoSaque = 80;

            var resultadoCedulas = _caixa.Saque(valorDoSaque);

            Assert.Equal(quantidadeDeCedulas, resultadoCedulas.Count);
        }

        [Fact(DisplayName = "Saque contem numero de cedulas igual ao predito")]
        [Trait("Operacao", "Saque")]
        public void Saque_Contem_Numero_De_Cedulas_Igual_Ao_Predito()
        {
            int quantidadeCedulas = 3;
            int valorSaque = 80;
            var resultdadoCedulas = _caixa.Saque(valorSaque);
            Assert.Equal(quantidadeCedulas, resultdadoCedulas.Count);
        }



    }
}
