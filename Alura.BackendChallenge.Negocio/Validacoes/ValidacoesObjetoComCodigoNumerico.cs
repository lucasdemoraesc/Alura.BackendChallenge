using Alura.BackendChallenge.Compartilhado.Globalizacoes;
using Alura.BackendChallenge.Dominio.Validadores;
using FluentValidation;

namespace Alura.BackendChallenge.Dominio.Objetos
{
    public abstract class ValidacoesObjetoComCodigoNumerico<TObjeto> : ValidadorAbstrato<TObjeto>
        where TObjeto : ObjetoComCodigoNumerico
    {
        #region VALIDACOES DE PROPRIEDADES

        #region CODIGO

        public void AssineRegraCodigoObrigatorio()
        {
            RuleFor(x => x.Codigo)
                .NotEmpty()
                .WithMessage(GlobalizacoesDeValidacao.CodigoObrigatorio);
        }

        public void AssineRegraCodigoValido()
        {
            RuleFor(x => x.Codigo)
                .Must(CodigoValido)
                .WithMessage(GlobalizacoesDeValidacao.CodigoValido);
        }

        #endregion

        #endregion

        #region MÉTODOS PRIVADOS

        private bool CodigoValido(int codigo)
        {
            return codigo != 0 && codigo.ToString().Length <= ObjetoComCodigoNumerico.TAMANHO_MAXIMO_CODIGO;
        }

        #endregion
    }
}
