using System.Collections.Generic;
using Alura.BackendChallenge.Dominio.Objetos.VideoObj;
using Alura.BackendChallenge.Interfaces.InterfacesDeRepositorio;
using Alura.BackendChallenge.Interfaces.Modelos;
using Alura.BackendChallenge.Negocio.Conversores.Interfaces;

namespace Alura.BackendChallenge.Negocio.Conversores
{
    /// <summary>
    /// Conversor de <see cref="DtoVideo"/> e <see cref="Video"/>.
    /// </summary>
    internal class ConversorDeVideo : IConversor<DtoVideo, Video>
    {
        /// <summary>
        /// Converte de Objeto para dto.
        /// </summary>
        /// <param name="objeto">O Objeto a ser convertido.</param>
        /// <returns>O Dto convertido.</returns>
        public DtoVideo Converta(Video video)
        {
            return video != null
                ? new DtoVideo
                {
                    Codigo = video.Codigo,
                    Titulo = video.Titulo,
                    Descricao = video.Descricao,
                    Url = video.Url
                }
                : null;
        }

        /// <summary>
        /// Converte de Dto para objeto.
        /// </summary>
        /// <param name="dto">O Dto a ser convertido.</param>
        /// <returns>O Objeto convertido.</returns>
        public Video Converta(DtoVideo dtoVideo)
        {
            return dtoVideo != null
                ? new Video
                {
                    Codigo = dtoVideo.Codigo,
                    Titulo = dtoVideo.Titulo,
                    Descricao = dtoVideo.Descricao,
                    Url = dtoVideo.Url
                }
                : null;
        }

        /// <summary>
        /// Converte uma lista de objetos para uma lista de Dtos.
        /// </summary>
        /// <param name="objetos">A lista de Objetos para conversão.</param>
        /// <returns>A lista de Dtos convertidos.</returns>
        public IList<DtoVideo> Converta(IList<Video> videos)
        {
            if (videos == null)
                return null;

            IList<DtoVideo> dtoVideos = new List<DtoVideo>();

            foreach (var objeto in videos)
            {
                dtoVideos.Add(Converta(objeto));
            }

            return dtoVideos;
        }

        /// <summary>
        /// Converte uma lista de Dtos para uma lista de Objetos.
        /// </summary>
        /// <param name="dtos">A lista de Dtos para conversão.</param>
        /// <returns>A lista de Objetos convertidos.</returns>
        public IList<Video> Converta(IList<DtoVideo> dtoVideos)
        {
            if (dtoVideos == null)
                return null;

            IList<Video> videos = new List<Video>();

            foreach (var dtoVideo in dtoVideos)
            {
                videos.Add(Converta(dtoVideo));
            }

            return videos;
        }

        /// <summary>
        /// Converte um Dto para um objeto persistido.
        /// </summary>
        /// <param name="repositorio">O repositório a ser utilizado para a consulta do objeto.</param>
        /// <param name="dto">O Dto a ser convertido.</param>
        /// <returns>O objeto persistido atualizado com os dados do Dto.</returns>
        public Video ConvertaParaObjetoPersistido(IRepositorioObjetoComCodigoNumerico<Video> repositorio, DtoVideo dto)
        {
            var videoPersistido = repositorio.Consulte(dto.Codigo);
            if (videoPersistido == null)
                return null;

            videoPersistido.Titulo = dto.Titulo;
            videoPersistido.Descricao = dto.Descricao;
            videoPersistido.Url = dto.Url;

            return videoPersistido;
        }
    }
}
