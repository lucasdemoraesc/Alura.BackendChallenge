using Alura.BackendChallenge.Dominio.Objetos.VideoObj;
using Alura.BackendChallenge.Interfaces.InterfacesDeRepositorio;

namespace Alura.BackendChallenge.Infraestrutura.Mapeadores.Repositorios
{
    /// <summary>
    /// Repositório do conceito <see cref="Video"/>
    /// </summary>
    public class RepositorioVideo : RepositorioObjetoComCodigoNumerico<Video>, IRepositorioVideo
    {
        /// <summary>
        /// Construtor padrão.
        /// </summary>
        /// <param name="contexto">O contexto da aplicação (via injeção de dependência).</param>
        public RepositorioVideo(ContextoPadrao contexto)
            : base(contexto) { }

        /// <summary>
        /// Atualiza apenas o Título do vídeo.
        /// </summary>
        /// <param name="video">O vídeo com o novo Título.</param>
        public void AtualizeTitulo(Video video)
        {
            Contexto.Entry(video).Property(x => x.Titulo).IsModified = true;
            Contexto.SaveChanges();
        }

        /// <summary>
        /// Atualiza apenas a Descrição do vídeo.
        /// </summary>
        /// <param name="video">O vídeo com a nova Descrição.</param>
        public void AtualizeDescricao(Video video)
        {
            Contexto.Entry(video).Property(x => x.Descricao).IsModified = true;
            Contexto.SaveChanges();
        }

        /// <summary>
        /// Atualiza apenas a Url do vídeo.
        /// </summary>
        /// <param name="video">O vídeo com a nova Url.</param>
        public void AtualizeUrl(Video video)
        {
            Contexto.Entry(video).Property(x => x.Url).IsModified = true;
            Contexto.SaveChanges();
        }
    }
}
