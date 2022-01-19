using System;

namespace TddNetCoreDev.Domain.Models
{

    public interface IConversorAltura
    {
       double PesParaMetros(double pes);
    }


    public class ConversorAltura : IConversorAltura
    {
        public double PesParaMetros(double pes)
        {
            return Math.Round(pes * 0.3048, 4);
        }
    }
}
