using System;
using System.Collections.Generic;
using System.Text;

namespace CursoOnlineTdd.Domain.Models
{
    public class CalculoFinanceiro
    {

        public static double CalcularValorComJurosCompostos(double valorEmprestimo, int numeroDeMeses, double percTaxa)
        {

            //M = C (1+i)t

            var fixedTax = 1 + (percTaxa / 100);
            var taxRaisedTime = Math.Pow(fixedTax, numeroDeMeses);
            var mountRounded = Math.Round(valorEmprestimo * taxRaisedTime, 2);
            return mountRounded;

            //return Math.Round(valorEmprestimo * Math.Pow(1 + (percTaxa / 100), numeroDeMeses), 2);
        }
    }
}
