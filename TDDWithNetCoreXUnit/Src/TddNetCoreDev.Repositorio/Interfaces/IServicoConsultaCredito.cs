using System.Collections.Generic;
using TddNetCoreDev.Repositorio.Models;

namespace TddNetCoreDev.Repositorio.Interfaces
{
    public interface IServicoConsultaCredito
    {
        IList<Pendencia> ConsultarPendenciasPorCPF(string cpf);
    }
}
