using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Alura.BackendChallenge.Dominio.Objetos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Alura.BackendChallenge.Infraestrutura.Utilitarios
{
    /// <summary>
    /// Utilitário para a geração de Código para objetos com código numérico.
    /// </summary>
    /// <typeparam name="TObjeto"><see cref="ObjetoComCodigoNumerico"/></typeparam>
    [Obsolete]
    internal class UtilitarioGeradorDeCodigo<TObjeto> : ValueGenerator<int>
        where TObjeto : ObjetoComCodigoNumerico
    {
        public override bool GeneratesTemporaryValues => false;

        private readonly ContextoPadrao _contexto;
        private readonly DbSet<TObjeto> _persistencia;

        /// <summary>
        /// Construtor padrão.
        /// </summary>
        /// <param name="contexto">O contexto da aplicação (via injeção de dependência).</param>
        public UtilitarioGeradorDeCodigo(ContextoPadrao contexto)
        {
            _contexto = contexto;
            _persistencia = _contexto.Set<TObjeto>();
        }

        /// <summary>
        /// Obtém o próximo Código para o conceito.
        /// </summary>
        /// <param name="entry">A entidade do contexto.</param>
        /// <returns>O próximo código.</returns>
        public override int Next([NotNull] EntityEntry entry) => ProximoCodigo();

        private int ProximoCodigo()
        {
            var ultimoCodigo = _persistencia.OrderByDescending(x => x.Codigo).FirstOrDefault();
            return 1;
        }
    }
}
