namespace Alura.BackendChallenge.Dominio.Objetos
{
    /// <summary>
    /// Classe abstrata para objetos com código numérico.
    /// </summary>
    public abstract class ObjetoComCodigoNumerico : ObjetoBase
    {
        #region CONSTANTES

        /// <summary>
        /// O tamanho máximo para o campo Código.
        /// </summary>
        public const int TAMANHO_MAXIMO_CODIGO = 6;

        #endregion

        #region PROPRIEDADES

        /// <summary>
        /// Obtém ou define o Código do objeto.
        /// </summary>
        public int Codigo { get; set; }

        #endregion
    }
}
