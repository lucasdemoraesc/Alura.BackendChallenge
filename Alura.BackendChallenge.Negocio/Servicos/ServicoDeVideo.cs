using Alura.BackendChallenge.Dominio.Objetos.VideoObj;
using Alura.BackendChallenge.Dominio.Validadores.Interfaces;
using Alura.BackendChallenge.Interfaces.InterfacesDeRepositorio;
using Alura.BackendChallenge.Interfaces.InterfacesDeServico;
using Alura.BackendChallenge.Interfaces.Modelos;
using Alura.BackendChallenge.Negocio.Conversores;
using Alura.BackendChallenge.Negocio.Conversores.Interfaces;

namespace Alura.BackendChallenge.Negocio.Servicos
{
    /// <summary>
    /// Classe de serviço para o conceito <see cref="Video"/>
    /// </summary>
    public class ServicoDeVideo : ServicoDeObjetoComCodigoNumerico<DtoVideo, Video>, IServicoDeVideo
    {
        private readonly IRepositorioVideo _repositorio;
        private IConversor<DtoVideo, Video> _conversor;

        /// <summary>
        /// Construtor padrão.
        /// </summary>
        /// <param name="repositorio">O repositório do contexto (via injeção de dependência).</param>
        public ServicoDeVideo(IRepositorioVideo repositorio)
            : base(repositorio)
        {
            _repositorio = repositorio;
        }

        /// <summary>
        /// Atualiza o Título de um vídeo.
        /// </summary>
        /// <param name="codigo">O código da ocorrência a ser atualizada.</param>
        /// <param name="novoTitulo">O novo Título.</param>
        public void AtualizeTitulo(int codigo, string novoTitulo)
        {
            var video = _repositorio.Consulte(codigo);
            video.Titulo = novoTitulo;

            var validador = Validador();
            validador.AssineRegrasAtualizacao();
            validador.Valide(video);
            validador.AssegureNenhumaInconsistencia();

            _repositorio.AtualizeTitulo(video);
        }

        /// <summary>
        /// Atualiza a Descrição de um vídeo.
        /// </summary>
        /// <param name="codigo">O código da ocorrência a ser atualizada.</param>
        /// <param name="novaDescricao">A nova Descrição.</param>
        public void AtualizeDescricao(int codigo, string novaDescricao)
        {
            var video = _repositorio.Consulte(codigo);
            video.Descricao = novaDescricao;

            var validador = Validador();
            validador.AssineRegrasAtualizacao();
            validador.Valide(video);
            validador.AssegureNenhumaInconsistencia();

            _repositorio.AtualizeDescricao(video);
        }

        /// <summary>
        /// Atualiza a Url de um vídeo.
        /// </summary>
        /// <param name="codigo">O código da ocorrência a ser atualizada.</param>
        /// <param name="novaUrl">A nova Url.</param>
        public void AtualizeUrl(int codigo, string novaUrl)
        {
            var video = _repositorio.Consulte(codigo);
            video.Url = novaUrl;

            var validador = Validador();
            validador.AssineRegrasAtualizacao();
            validador.Valide(video);
            validador.AssegureNenhumaInconsistencia();

            _repositorio.AtualizeDescricao(video);
        }

        /// <summary>
        /// Obtém a instância do conversor de vídeo.
        /// </summary>
        /// <returns>Uma nova instância do conversor de vídeo.</returns>
        protected override IConversor<DtoVideo, Video> Conversor()
        {
            return _conversor ??= new ConversorDeVideo();
        }

        /// <summary>
        /// Obtém a instância da classe de validação de vídeo.
        /// </summary>
        /// <returns>Uma nova instância do validador de vídeo.</returns>
        protected override IValidador<Video> Validador()
        {
            return new ValidacoesDeVideo(_repositorio);
        }
    }
}
