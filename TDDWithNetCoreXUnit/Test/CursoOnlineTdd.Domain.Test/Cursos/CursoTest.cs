using ExpectedObjects;
using System;
using TddNetCoreDev.Domain;
using TddNetCoreDev.Domain.Enums;
using TDDWithNetCoreXUnit.Test.Utilidades;
using Xunit;

namespace TDDWithNetCoreXUnit.Test.Cursos
{
    public class CursoTest
    {
        [Fact(DisplayName = "CriacaoDoCurso")]
        public void CriarCurso()
        {
            //AQUI USO A FORMA SEM UTILIZAÇÃO DA BIBLIOTEC EXPECTEDOBJECTS PARA VALIDAÇÃO DOS OBJETOS:
            //string nome = "Informatica basica";
            //double cargaHoraria = 40;
            //string publicoAlvo = "Estudante";
            //double valor = 50;

            //var curso = new Curso(nome, cargaHoraria, publicoAlvo, valor);

            //Assert.Equal(nome, curso.Nome);
            //Assert.Equal(cargaHoraria, curso.CargaHoraria);
            //Assert.Equal(publicoAlvo, curso.PublicoAlvo);
            //Assert.Equal(valor, curso.Valor);



            //FORMA COM BIBLIOTECA:
            var cursoEsperado = new
            {
                Nome = "Informatica basica",
                CargaHoraria = (double)40,
                PublicoAlvo = PublicoAlvoEnum.Estudante,
                Valor = (double)50
            };


            var curso = new Curso(cursoEsperado.Nome, cursoEsperado.CargaHoraria,
                                  cursoEsperado.PublicoAlvo, cursoEsperado.Valor);

            cursoEsperado.ToExpectedObject().ShouldMatch(curso);
        }


        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Curso_NomeVazioOuNulo_RetornarArgumentNullException(string nomeInvalido)
        {
            var cursoEsperado = new
            {
                Nome = "Informatica basica",
                CargaHoraria = (double)40,
                PublicoAlvo = PublicoAlvoEnum.Estudante,
                Valor = (double)50
            };

            Assert.Throws<ArgumentException>(() => new Curso(nomeInvalido, cursoEsperado.CargaHoraria,
                                  cursoEsperado.PublicoAlvo, cursoEsperado.Valor));
        }


        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        public void Curso_CargaHorariaMenorQue1_RetornaArgumentException(double cargaHoraria)
        {
            var cursoEsperado = new
            {
                Nome = "Informatica basica",
                CargaHoraria = (double)40,
                PublicoAlvo = PublicoAlvoEnum.Estudante,
                Valor = (double)50
            };

            string messageError = "Carga Horária menor que o valor permitido";

            Assert.Throws<ArgumentException>(() => new Curso(cursoEsperado.Nome, cargaHoraria,
                                   cursoEsperado.PublicoAlvo, cursoEsperado.Valor)).ValidarMenssagem(messageError);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Curso_ValorCursoMenorQue1_RetornaArgumentExpetion(double valorCurso)
        {
            var cursoEsperado = new
            {
                Nome = "Informatica basica",
                CargaHoraria = (double)40,
                PublicoAlvo = PublicoAlvoEnum.Estudante,
                Valor = (double)50
            };

            string messageError = "Valor do Curso menor que valor permitido";

            Assert.Throws<ArgumentException>(() => new Curso(cursoEsperado.Nome, cursoEsperado.CargaHoraria,
                                cursoEsperado.PublicoAlvo, valorCurso)).ValidarMenssagem(messageError);
        }

    }

}
