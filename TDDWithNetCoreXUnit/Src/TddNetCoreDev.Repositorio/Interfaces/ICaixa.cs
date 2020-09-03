using System.Collections.Generic;

namespace TddNetCoreDev.Repositorio.Interfaces
{
    public interface ICaixa
    {
        ICollection<int> Saque(int valor);
        bool ValidaCedulasDisponiveis(int valor);
    }
}
