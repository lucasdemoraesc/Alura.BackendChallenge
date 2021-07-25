namespace Alura.BackendChallenge.Dominio.Objetos.VideoObj
{
    /// <summary>
    /// Conceito Video.
    /// </summary>
    public class Video : ObjetoComCodigoNumerico
    {
        #region CONSTANTES

        /// <summary>
        /// O tamanho máximo para o campo Título.
        /// </summary>
        public const int TAMANHO_MAXIMO_TITULO = 30;

        /// <summary>
        /// O tamanho máximo para o campo Descrição.
        /// </summary>
        public const int TAMANHO_MAXIMO_DESCRICAO = 60;

        /// <summary>
        /// O tamanho máximo para o campo Url.
        /// </summary>
        public const int TAMANHO_MAXIMO_URL = 120;

        #endregion

        #region PROPRIEDADES

        /// <summary>
        /// Obtém ou define o Título do objeto.
        /// </summary>
        public string Titulo { get; set; }

        /// <summary>
        /// Obtém ou define a Descrição do objeto.
        /// </summary>
        public string Descricao { get; set; }

        /// <summary>
        /// Obtém ou define a Url do objeto.
        /// </summary>
        public string Url { get; set; }

        #endregion
    }
}
