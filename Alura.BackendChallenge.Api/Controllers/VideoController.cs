using System.Collections.Generic;
using Alura.BackendChallenge.Interfaces.InterfacesDeServico;
using Alura.BackendChallenge.Interfaces.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Alura.BackendChallenge.API.Controllers
{
    /// <summary>
    /// Controller do conceito <see cref="DtoVideo"/>
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class VideoController : ControllerBase
    {
        private IServicoDeVideo _servico;

        /// <summary>
        /// Construtor padrão para o Controller de Video.
        /// </summary>
        /// <param name="servico">Uma implementação da interface <see cref="IServicoDeVideo"/>.</param>
        public VideoController(IServicoDeVideo servico)
        {
            _servico = servico;
        }

        /// <summary>
        /// Adiciona um novo registro à base de dados.
        /// </summary>
        /// <param name="dtoVideo">O <see cref="DtoVideo"/> a ser cadastrado.</param>
        /// <returns>O <see cref="DtoVideo"/> cadastrado.</returns>
        [HttpPost]
        public IActionResult Cadastre([FromBody] DtoVideo dtoVideo)
        {
            _servico.Cadastre(dtoVideo);
            var videoCadastrado = _servico.Consulte(dtoVideo.Codigo);

            return CreatedAtAction(nameof(Consulte), new { Codigo = dtoVideo.Codigo }, dtoVideo);
        }

        /// <summary>
        /// Consulta um registro da base.
        /// </summary>
        /// <param name="codigo">O código do registro.</param>
        /// <returns>O <see cref="DtoVideo"/> cadastrado ou Status 404.</returns>
        [HttpGet("{codigo}")]
        [ProducesResponseType(typeof(IEnumerable<DtoVideo>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Consulte(int codigo)
        {
            var video = _servico.Consulte(codigo);
            return video is null ? NotFound() : Ok(video);
        }

        /// <summary>
        /// Consulta a lista de registros da base.
        /// </summary>
        /// <param name="qtdeAPular">A quantidade de registros a ser pulada (Nenhum por padrão).</param>
        /// <param name="qtdeARetornar">A quantidade de registro que deverá retornar (Todos por padrão).</param>
        /// <returns>Uma lista de <see cref="DtoVideo"/>.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(DtoVideo), StatusCodes.Status200OK)]
        public IActionResult ConsulteLista([FromHeader] int qtdeAPular = 0, [FromHeader] int qtdeARetornar = 0)
        {
            return Ok(qtdeAPular == 0 && qtdeARetornar == 0
                ? _servico.ConsulteLista()
                : _servico.ConsulteLista(qtdeAPular, qtdeARetornar));
        }

        [HttpPut("{codigo}")]
        public IActionResult Atualize([FromRoute] int codigo, [FromBody] DtoVideo dtoVideo)
        {
            _servico.Atualize(dtoVideo);

            var videoCadastrado = _servico.Consulte(dtoVideo.Codigo);
            return CreatedAtAction(nameof(Consulte), new { Codigo = dtoVideo.Codigo }, dtoVideo);
        }

        [HttpPatch("{codigo}/titulo")]
        public IActionResult AtualizeTitulo([FromRoute] int codigo, [FromBody] string novoTitulo)
        {
            _servico.AtualizeTitulo(codigo, novoTitulo);
            return NoContent();
        }

        /// <summary>
        /// Exclui um registro da base.
        /// </summary>
        /// <param name="codigo">O código do registro.</param>
        /// <returns>Retorna status 200 se o registro for excluído e 404 caso não encontrado.</returns>
        [HttpDelete("{codigo}")]
        [ProducesResponseType(typeof(DtoVideo), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Exclua(int codigo)
        {
            var excluido = _servico.Exclua(codigo);
            return excluido ? Ok() : NotFound();
        }
    }
}
