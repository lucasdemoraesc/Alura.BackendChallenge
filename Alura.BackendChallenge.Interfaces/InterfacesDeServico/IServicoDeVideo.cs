using Alura.BackendChallenge.Dominio.Objetos.VideoObj;
using Alura.BackendChallenge.Interfaces.Modelos;

namespace Alura.BackendChallenge.Interfaces.InterfacesDeServico
{
    /// <summary>
    /// Interface de serviço para o conceito <see cref="Video"/>
    /// </summary>
    public interface IServicoDeVideo : IServicoDeObjetoComCodigoNumerico<DtoVideo, Video>
    {
        /// <summary>
        /// Atualiza o Título de um vídeo.
        /// </summary>
        /// <param name="codigo">O código da ocorrência a ser atualizada.</param>
        /// <param name="novoTitulo">O novo Título.</param>
        void AtualizeTitulo(int codigo, string novoTitulo);

        /// <summary>
        /// Atualiza a Descrição de um vídeo.
        /// </summary>
        /// <param name="codigo">O código da ocorrência a ser atualizada.</param>
        /// <param name="novaDescricao">A nova Descrição.</param>
        void AtualizeDescricao(int codigo, string novaDescricao);

        /// <summary>
        /// Atualiza a Url de um vídeo.
        /// </summary>
        /// <param name="codigo">O código da ocorrência a ser atualizada.</param>
        /// <param name="novaUrl">A nova Url.</param>
        void AtualizeUrl(int codigo, string novaUrl);
    }
}
