using TddNetCoreDev.Repositorio.Enums;
using TddNetCoreDev.Repositorio.Interfaces;

namespace TddNetCoreDev.Repositorio.BLL
{
    public class AnaliseCredito
    {
        private IServicoConsultaCredito _servConsultaCredito;

        public AnaliseCredito(IServicoConsultaCredito servConsultaCredito)
        {
            _servConsultaCredito = servConsultaCredito;
        }


        public StatusConsultaCredito ConsultarSituacaoCPF(string cpf)
        {
            try
            {
                var pendencias = _servConsultaCredito.ConsultarPendenciasPorCPF(cpf);

                if (pendencias == null)
                    return StatusConsultaCredito.ParametroEnvioInvalido;
                else if (pendencias.Count == 0)
                    return StatusConsultaCredito.SemPendencias;
                else
                    return StatusConsultaCredito.Inadimplente;

            }
            catch (System.Exception)
            {
                return StatusConsultaCredito.ErroComunicacao;
            }
        }
    }
}
