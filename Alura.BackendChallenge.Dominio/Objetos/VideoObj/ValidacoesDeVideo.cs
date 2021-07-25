namespace Alura.BackendChallenge.Dominio.Objetos.VideoObj
{
    /// <summary>
    /// Classe para validações de <see cref="Video"/>
    /// </summary>
    public class ValidacoesDeVideo : ValidacoesObjetoComCodigoNumerico<Video>
    {
        public const int TAMANHO_MAXIMO_TITULO = 30;
        public const int TAMANHO_MAXIMO_DESCRICAO = 60;
        public const int TAMANHO_MAXIMO_URL = 120;


        #region FLUXOS DE VALIDAÇÃO

        public override void AssineValidadorCadastro()
        {
            throw new System.NotImplementedException();
        }

        public override void AssineValidadorAtualizacao()
        {
            throw new System.NotImplementedException();
        }

        public override void AssineValidadorExclusao()
        {
            AssineRegraCodigoObrigatorio();
            AssineRegraCodigoValido();
        }

        #endregion
    }
}
