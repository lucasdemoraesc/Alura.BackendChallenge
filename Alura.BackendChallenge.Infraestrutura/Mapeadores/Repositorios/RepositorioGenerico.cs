using Alura.BackendChallenge.Dominio.Objetos;
using Alura.BackendChallenge.Interfaces.InterfacesDeRepositorio;
using Microsoft.EntityFrameworkCore;

namespace Alura.BackendChallenge.Infraestrutura.Mapeadores.Repositorios
{
    /// <summary>
    /// Repositorio Generico abstrato.
    /// Define o contexto e o DbSet a serem utilizados.
    /// </summary>
    /// <typeparam name="TObjeto"><see cref="ObjetoBase"/></typeparam>
    public abstract class RepositorioGenerico<TObjeto> : IRepositorioGenerico<TObjeto>
        where TObjeto : ObjetoBase
    {
        protected readonly ContextoPadrao Contexto;
        protected readonly DbSet<TObjeto> Persistencia;

        /// <summary>
        /// Construtor padrão.
        /// </summary>
        /// <param name="contexto">O contexto da aplicação (via injeção de dependência).</param>
        public RepositorioGenerico(ContextoPadrao contexto)
        {
            Contexto = contexto;
            Persistencia = Contexto.Set<TObjeto>();
        }

    }
}
