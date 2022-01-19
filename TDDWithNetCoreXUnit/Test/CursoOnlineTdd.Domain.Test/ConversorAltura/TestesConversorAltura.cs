using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using TddNetCoreDev.Domain.Models;
using Xunit;


namespace TDDWithNetCoreXUnit.Test.ConversaoAltura
{
    public class TestesConversorAltura
    {
        //[Fact] é mais usadoquando queremos testarsomente um cenário.
        [Theory]
        [InlineData(1, 0.3048)]
        [InlineData(10, 3.048)]
        [InlineData(55.5555, 16.9333)]
        [InlineData(100, 30.48)]
        public void TesteConversorAltura(double pes, double metros)
        {
            ConversorAltura conversor = new ConversorAltura();
            double resultado = conversor.PesParaMetros(pes);

            //Assert.Equal(metro, resultado);
            resultado.Should().Be(metros, "Altura em metros não corresponde ao valor esperado de " + metros);
        }
    }
}
