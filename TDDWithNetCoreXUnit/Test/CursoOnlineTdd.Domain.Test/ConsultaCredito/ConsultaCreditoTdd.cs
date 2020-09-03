using NSubstitute;
using System;
using System.Collections.Generic;
using TddNetCoreDev.Repositorio.BLL;
using TddNetCoreDev.Repositorio.Enums;
using TddNetCoreDev.Repositorio.Interfaces;
using TddNetCoreDev.Repositorio.Models;
using Xunit;

namespace TDDWithNetCoreXUnit.Test.ConsultaCredito
{
    public class ConsultaCreditoTdd
    {
        private const string CPF_INVALIDO = "123A";
        private const string CPF_ERRO_COMUNICACAO = "76217486300";
        private const string CPF_SEM_PENDENCIAS = "60487583752";
        private const string CPF_INADIMPLENTE = "82226651209";


        private IServicoConsultaCredito interfaceMock;

        public ConsultaCreditoTdd()
        {
            interfaceMock = Substitute.For<IServicoConsultaCredito>();

            interfaceMock.ConsultarPendenciasPorCPF(CPF_INVALIDO).Returns((List<Pendencia>)null);

            interfaceMock.ConsultarPendenciasPorCPF(CPF_ERRO_COMUNICACAO).Returns(s => { throw new Exception("Erro de comunicação..."); });

            interfaceMock.ConsultarPendenciasPorCPF(CPF_SEM_PENDENCIAS).Returns(new List<Pendencia>());

            Pendencia pendencia = new Pendencia();
            pendencia.CPF = CPF_INADIMPLENTE;
            pendencia.NomePessoa = "João da Silva";
            pendencia.NomeReclamante = "Empresa XYZ";
            pendencia.DescricaoPendencia = "Parcela não paga";
            pendencia.VlPendencia = 700;
            List<Pendencia> pendencias = new List<Pendencia>();
            pendencias.Add(pendencia);

            interfaceMock.ConsultarPendenciasPorCPF(CPF_INADIMPLENTE)
                .Returns(pendencias);
        }

        private StatusConsultaCredito ObterStatusAnaliseCredito(string cpf)
        {
            AnaliseCredito analise = new AnaliseCredito(interfaceMock);
            return analise.ConsultarSituacaoCPF(cpf);
        }

        [Fact]
        public void TestarErroComunicacao()
        {
            StatusConsultaCredito status = ObterStatusAnaliseCredito(CPF_ERRO_COMUNICACAO);
            Assert.Equal(StatusConsultaCredito.ErroComunicacao, status);
        }

        [Fact]
        public void TestarCpfSemPendencias()
        {
            StatusConsultaCredito status = ObterStatusAnaliseCredito(CPF_SEM_PENDENCIAS);
            Assert.Equal(StatusConsultaCredito.SemPendencias, status);
        }

        [Fact]
        public void TestarCPFComPendencia()
        {
            StatusConsultaCredito status = ObterStatusAnaliseCredito(CPF_INADIMPLENTE);
            Assert.Equal(StatusConsultaCredito.Inadimplente, status);
        }

        [Fact]
        public void TestarCPF()
        {
            StatusConsultaCredito status = ObterStatusAnaliseCredito(CPF_ERRO_COMUNICACAO);
            Assert.Equal(StatusConsultaCredito.ErroComunicacao, status);
        }

        [Fact]
        public void TestarCPFParametroInvalido()
        {
            StatusConsultaCredito status = ObterStatusAnaliseCredito(CPF_INVALIDO);
            Assert.Equal(StatusConsultaCredito.ParametroEnvioInvalido, status);
        }

    }
}
