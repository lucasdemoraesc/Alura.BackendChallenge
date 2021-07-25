using System.Collections.Generic;
using Alura.BackendChallenge.Dominio.Objetos;
using Alura.BackendChallenge.Interfaces.InterfacesDeRepositorio;
using Alura.BackendChallenge.Interfaces.Modelos;

namespace Alura.BackendChallenge.Negocio.Conversores.Interfaces
{
    /// <summary>
    /// Interface genérica de conversor.
    /// </summary>
    /// <typeparam name="TDto"><see cref="DtoBase"/></typeparam>
    /// <typeparam name="TObjeto"><see cref="ObjetoComCodigoNumerico"/></typeparam>
    public interface IConversor<TDto, TObjeto>
        where TDto : DtoBase
        where TObjeto : ObjetoComCodigoNumerico
    {
        /// <summary>
        /// Converte de Objeto para dto.
        /// </summary>
        /// <param name="objeto">O Objeto a ser convertido.</param>
        /// <returns>O Dto convertido.</returns>
        TDto Converta(TObjeto objeto);

        /// <summary>
        /// Converte de Dto para objeto.
        /// </summary>
        /// <param name="dto">O Dto a ser convertido.</param>
        /// <returns>O Objeto convertido.</returns>
        TObjeto Converta(TDto dto);

        /// <summary>
        /// Converte uma lista de objetos para uma lista de Dtos.
        /// </summary>
        /// <param name="objetos">A lista de Objetos para conversão.</param>
        /// <returns>A lista de Dtos convertidos.</returns>
        IList<TDto> Converta(IList<TObjeto> objetos);

        /// <summary>
        /// Converte uma lista de Dtos para uma lista de Objetos.
        /// </summary>
        /// <param name="dtos">A lista de Dtos para conversão.</param>
        /// <returns>A lista de Objetos convertidos.</returns>
        IList<TObjeto> Converta(IList<TDto> dtos);

        /// <summary>
        /// Converte um Dto para um objeto persistido.
        /// </summary>
        /// <param name="repositorio">O repositório a ser utilizado para a consulta do objeto.</param>
        /// <param name="dto">O Dto a ser convertido.</param>
        /// <returns>O objeto persistido atualizado com os dados do Dto.</returns>
        TObjeto ConvertaParaObjetoPersistido(IRepositorioObjetoComCodigoNumerico<TObjeto> repositorio, TDto dto);
    }
}
