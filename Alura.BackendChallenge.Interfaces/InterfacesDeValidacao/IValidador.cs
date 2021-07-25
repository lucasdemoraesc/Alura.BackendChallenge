using Alura.BackendChallenge.Dominio.Objetos;
using FluentValidation.Results;

namespace Alura.BackendChallenge.Dominio.Validadores.Interfaces
{
    public interface IValidador<TObjeto>
        where TObjeto : ObjetoBase
    {
        ValidationResult resultados { get; }

        void AssineRegrasCadastro();

        void AssineRegrasAtualizacao();

        void AssineRegrasExclusao();

        abstract void Valide(TObjeto objeto);

        abstract void AssegureNenhumaInconsistencia();
    }
}
