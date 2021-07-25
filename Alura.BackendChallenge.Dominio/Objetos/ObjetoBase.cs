using System;

namespace Alura.BackendChallenge.Dominio.Objetos
{
    /// <summary>
    /// Classe abstrata base com Identificador.
    /// </summary>
    public abstract class ObjetoBase
    {
        /// <summary>
        /// Obtém o Identificador do vídeo (Usado apenas internamente).
        /// </summary>
        public Guid Id { get; set; }
    }
}
