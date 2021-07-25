using Alura.BackendChallenge.Dominio.Objetos;

namespace Alura.BackendChallenge.Dominio.Validadores.Interfaces
{
    public interface IProvedorDeValidacoes<TObjeto>
        where TObjeto : ObjetoBase
    {
        void AssineValidadorCadastro();

        void AssineValidadorAtualizacao();

        void AssineValidadorExclusao();
    }
}
