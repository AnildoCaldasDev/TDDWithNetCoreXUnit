using ConsultaCredito.Models;
using System.Collections.Generic;

namespace ConsultaCredito.Interfaces
{
    public interface IServicoConsultaCredito
    {
        IList<Pendencia> ConsultarPendenciasPorCPF(string cpf);
    }
}
