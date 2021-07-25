using System.Collections.Generic;
using System.Linq;
using Alura.BackendChallenge.Dominio.Objetos;
using Alura.BackendChallenge.Interfaces.InterfacesDeRepositorio;

namespace Alura.BackendChallenge.Infraestrutura.Mapeadores.Repositorios
{
    /// <summary>
    /// Repositório abstrato para objetos com código numéricos.
    /// </summary>
    /// <typeparam name="TObjeto"><see cref="ObjetoComCodigoNumerico"/></typeparam>
    public abstract class RepositorioObjetoComCodigoNumerico<TObjeto> : RepositorioGenerico<TObjeto>, IRepositorioObjetoComCodigoNumerico<TObjeto>
        where TObjeto : ObjetoComCodigoNumerico
    {
        /// <summary>
        /// Construtor padrão.
        /// </summary>
        /// <param name="contexto">O contexto da aplicação (via injeção de dependência).</param>
        public RepositorioObjetoComCodigoNumerico(ContextoPadrao contexto)
            : base(contexto) { }

        /// <summary>
        /// Cadastra um novo objeto no contexto definido.
        /// </summary>
        /// <param name="objeto">O objeto a ser cadastrado.</param>
        public virtual void Cadastre(TObjeto objeto)
        {
            Persistencia.Add(objeto);
            Contexto.SaveChanges();
        }

        /// <summary>
        /// Consulta um objeto no contexto definido.
        /// </summary>
        /// <param name="Codigo">O código do objeto.</param>
        /// <returns>O objeto da base, ou null caso não exista.</returns>
        public virtual TObjeto Consulte(int Codigo)
        {
            return Persistencia.Where(x => x.Codigo == Codigo).FirstOrDefault();
        }

        /// <summary>
        /// Consulta todos os registros no contexto definido.
        /// </summary>
        /// <returns>Uma lista com os registros.</returns>
        public virtual IList<TObjeto> ConsulteLista()
        {
            return Persistencia.OrderBy(x => x.Codigo).ToList();
        }

        /// <summary>
        /// Consulta uma lista parcial dos registros no contexto definido.
        /// </summary>
        /// <param name="qtdeAPular">A quantidade de registros a ser pulada a partir do primeiro.</param>
        /// <param name="qtdeARetornar">A quantidade de registros a ser retornada.</param>
        /// <returns>Uma lista com os registros.</returns>
        public virtual IList<TObjeto> ConsulteLista(int qtdeAPular, int qtdeARetornar)
        {
            return Persistencia.OrderBy(x => x.Codigo).Skip(qtdeAPular).Take(qtdeARetornar).ToList();
        }

        /// <summary>
        /// Atualiza um registro no contexto definido.
        /// </summary>
        /// <param name="objeto">O objeto modificado.</param>
        public virtual void Atualize(TObjeto objeto)
        {
            Persistencia.Update(objeto);
            Contexto.SaveChanges();
        }

        /// <summary>
        /// Exclui um registro no contexto.
        /// </summary>
        /// <param name="objeto">O objeto a ser excluído.</param>
        public virtual void Exclua(TObjeto objeto)
        {
            Persistencia.Remove(objeto);
            Contexto.SaveChanges();
        }
    }
}
