using FluentAssertions;
using TddNetCoreDev.Domain.Models;
using Xunit;

namespace TDDWithNetCoreXUnit.Test.CaixaEletronico
{
    public class CaixaEletronicoFluentAssertionTests
    {
        [Fact(DisplayName = "Valores do modelo cedula estão corretos")]
        public void ValoresModeloCedulaEstaoCorretos()
        {
            Cedula.Cem.Should().Be(100);
            Cedula.Cinquenta.Should().BeOfType(typeof(int)).And.Be(50);
            Cedula.Vinte.Should().BeOfType(typeof(int)).And.Be(20);
            Cedula.Dez.Should().BeOfType(typeof(int)).And.Be(10);
        }


        [Fact(DisplayName = "Intervalos de valores do modelo cedula estão corretos")]
        public void IntervalosValoresModeloscedulasEstaoCorretos()
        {
            Cedula.Cinquenta.Should().BeLessThan(Cedula.Cem);
            Cedula.Dez.Should().BeLessThan(Cedula.Vinte);
        }


    }
}
