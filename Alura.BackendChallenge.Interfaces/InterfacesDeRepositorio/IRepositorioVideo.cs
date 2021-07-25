using Alura.BackendChallenge.Dominio.Objetos.VideoObj;

namespace Alura.BackendChallenge.Interfaces.InterfacesDeRepositorio
{
    /// <summary>
    /// Interface de repositório do conceito <see cref="Video"/>
    /// </summary>
    public interface IRepositorioVideo : IRepositorioObjetoComCodigoNumerico<Video>
    {
        /// <summary>
        /// Atualiza apenas o Título do vídeo.
        /// </summary>
        /// <param name="video">O vídeo com o novo Título.</param>
        void AtualizeTitulo(Video video);

        /// <summary>
        /// Atualiza apenas a Descrição do vídeo.
        /// </summary>
        /// <param name="video">O vídeo com a nova Descrição.</param>
        void AtualizeDescricao(Video video);

        /// <summary>
        /// Atualiza apenas a Url do vídeo.
        /// </summary>
        /// <param name="video">O vídeo com a nova Url.</param>
        void AtualizeUrl(Video video);
    }
}
