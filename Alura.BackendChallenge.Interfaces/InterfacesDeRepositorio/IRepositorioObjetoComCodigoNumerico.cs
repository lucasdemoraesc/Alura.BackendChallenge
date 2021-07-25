using System.Collections.Generic;
using Alura.BackendChallenge.Dominio.Objetos;

namespace Alura.BackendChallenge.Interfaces.InterfacesDeRepositorio
{
    /// <summary>
    /// Interface de repositório para objetos com código numérico.
    /// </summary>
    /// <typeparam name="TObjeto"><see cref="ObjetoComCodigoNumerico"/></typeparam>
    public interface IRepositorioObjetoComCodigoNumerico<TObjeto> : IRepositorioGenerico<TObjeto>
        where TObjeto : ObjetoComCodigoNumerico
    {
        /// <summary>
        /// Cadastra um novo objeto no contexto definido.
        /// </summary>
        /// <param name="objeto">O objeto a ser cadastrado.</param>
        void Cadastre(TObjeto objeto);

        /// <summary>
        /// Consulta um objeto no contexto definido.
        /// </summary>
        /// <param name="Codigo">O código do objeto.</param>
        /// <returns>O objeto da base, ou null caso não exista.</returns>
        TObjeto Consulte(int Codigo);

        /// <summary>
        /// Consulta todos os registros no contexto definido.
        /// </summary>
        /// <returns>Uma lista com os registros.</returns>
        IList<TObjeto> ConsulteLista();

        /// <summary>
        /// Consulta uma lista parcial dos registros no contexto definido.
        /// </summary>
        /// <param name="qtdeAPular">A quantidade de registros a ser pulada a partir do primeiro.</param>
        /// <param name="qtdeARetornar">A quantidade de registros a ser retornada.</param>
        /// <returns>Uma lista com os registros.</returns>
        IList<TObjeto> ConsulteLista(int qtdeAPular, int qtdeARetornar);

        /// <summary>
        /// Atualiza um registro no contexto definido.
        /// </summary>
        /// <param name="objeto">O objeto modificado.</param>
        void Atualize(TObjeto objeto);

        /// <summary>
        /// Exclui um registro no contexto.
        /// </summary>
        /// <param name="objeto">O objeto a ser excluído.</param>
        void Exclua(TObjeto objeto);
    }
}
