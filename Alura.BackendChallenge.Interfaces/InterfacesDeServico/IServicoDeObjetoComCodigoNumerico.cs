using System.Collections.Generic;
using Alura.BackendChallenge.Dominio.Objetos;
using Alura.BackendChallenge.Interfaces.Modelos;

namespace Alura.BackendChallenge.Interfaces.InterfacesDeServico
{
    /// <summary>
    /// Interface de servico para objetos com código numérico.
    /// </summary>
    /// <typeparam name="TDto"><see cref="DtoBase"/></typeparam>
    /// <typeparam name="TObjeto"><see cref="ObjetoComCodigoNumerico"/></typeparam>
    public interface IServicoDeObjetoComCodigoNumerico<TDto, TObjeto>
        where TDto : DtoBase
        where TObjeto : ObjetoComCodigoNumerico
    {
        /// <summary>
        /// Cadastra uma nova ocorrência do conceito no contexto.
        /// </summary>
        /// <param name="dto">A instância a ser cadastrada.</param>
        void Cadastre(TDto dto);

        /// <summary>
        /// Consulte uma ocorrência do conceito por código.
        /// </summary>
        /// <param name="codigo">O código da ocorrência.</param>
        /// <returns>Uma instância do conceito.</returns>
        TDto Consulte(int codigo);

        /// <summary>
        /// Consulta todos os conceitos do contexto.
        /// </summary>
        /// <returns>Uma lista com os registros.</returns>
        IList<TDto> ConsulteLista();

        /// <summary>
        /// Consulta uma lista parcial dos conceitos do contexto
        /// </summary>
        /// <param name="qtdeAPular">A quantidade de registros a ser pulada a partir do primeiro.</param>
        /// <param name="qtdeARetornar">A quantidade de registros a ser retornada.</param>
        /// <returns></returns>
        IList<TDto> ConsulteLista(int qtdeAPular, int qtdeARetornar);

        /// <summary>
        /// Atualiza um registro do conceito já cadastrada no contexto.
        /// </summary>
        /// <param name="dto">Os novos valores (Exceto o código).</param>
        void Atualize(TDto dto);

        /// <summary>
        /// Exlui um registro do contexto.
        /// </summary>
        /// <param name="codigo">O código do registro a ser excluído.</param>
        /// <returns>True se o objeto existir, False caso o contrário.</returns>
        bool Exclua(int codigo);
    }
}
