using CursoOnlineTdd.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CursoOnlineTdd.Domain
{
    public class Curso
    {
        public string Nome { get; set; }
        public double CargaHoraria { get; set; }
        public PublicoAlvoEnum PublicoAlvo { get; set; }
        public double Valor { get; set; }


        public Curso(string nome, double cargaHoraria, PublicoAlvoEnum publicoAlvo, double valor)
        {

            if (String.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Parâmetro nome Inválido");

            if (cargaHoraria < 1)
                throw new ArgumentException("Carga Horária menor que o valor permitido");

            if (valor < 1)
                throw new ArgumentException("Valor do Curso menor que valor permitido");

            this.Nome = nome;
            this.CargaHoraria = cargaHoraria;
            this.PublicoAlvo = publicoAlvo;
            this.Valor = valor;

        }
    }
}
