namespace Alura.BackendChallenge.Interfaces.Modelos
{
    /// <summary>
    /// Dto de vídeo.
    /// </summary>
    public class DtoVideo : DtoBase
    {
        /// <summary>
        /// O Título do vídeo.
        /// </summary>
        public string Titulo { get; set; }

        /// <summary>
        /// A Descrição do vídeo.
        /// </summary>
        public string Descricao { get; set; }

        /// <summary>
        /// A Url do vídeo.
        /// </summary>
        public string Url { get; set; }
    }
}
