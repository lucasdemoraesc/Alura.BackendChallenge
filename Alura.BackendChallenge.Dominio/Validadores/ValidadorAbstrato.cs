using Alura.BackendChallenge.Dominio.Objetos;
using Alura.BackendChallenge.Dominio.Validadores.Interfaces;
using FluentValidation;

namespace Alura.BackendChallenge.Dominio.Validadores
{
    public abstract class ValidadorAbstrato<TObjeto>
        : AbstractValidator<TObjeto>,
        IProvedorDeValidacoes<TObjeto>
        where TObjeto : ObjetoBase
    {
        public abstract void AssineValidadorAtualizacao();

        public abstract void AssineValidadorCadastro();

        public abstract void AssineValidadorExclusao();
    }
}
