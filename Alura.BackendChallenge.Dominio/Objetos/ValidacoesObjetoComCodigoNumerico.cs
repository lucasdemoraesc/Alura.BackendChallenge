using Alura.BackendChallenge.Compartilhado.Globalizacoes;
using Alura.BackendChallenge.Dominio.Validadores;
using FluentValidation;

namespace Alura.BackendChallenge.Dominio.Objetos
{
    public abstract class ValidacoesObjetoComCodigoNumerico<TObjeto> : ValidadorAbstrato<TObjeto>
        where TObjeto : ObjetoComCodigoNumerico
    {
        public const int TAMANHO_MAXIMO_CODIGO = 6;

        #region VALIDACOES DE PROPRIEDADES

        #region CODIGO

        public void AssineRegraCodigoObrigatorio()
        {
            RuleFor(x => x.Codigo)
                .NotEmpty()
                .WithMessage(GloalizacoesDeValidacao.CodigoObrigatorio);
        }

        public void AssineRegraCodigoValido()
        {
            RuleFor(x => x.Codigo)
                .Must(CodigoValido)
                .WithMessage(GloalizacoesDeValidacao.CodigoValido);
        }

        #endregion

        #endregion

        #region MÉTODOS PRIVADOS

        private bool CodigoValido(int codigo)
        {
            return codigo is > 0 and < 999999;
        }

        #endregion
    }
}
