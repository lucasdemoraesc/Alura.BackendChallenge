using System;
using System.Text.Json;
using Alura.BackendChallenge.Dominio.Objetos;
using Alura.BackendChallenge.Dominio.Validadores.Interfaces;
using FluentValidation;
using FluentValidation.Results;

namespace Alura.BackendChallenge.Dominio.Validadores
{
    public abstract class ValidadorAbstrato<TObjeto>
        : AbstractValidator<TObjeto>,
        IValidador<TObjeto>
        where TObjeto : ObjetoBase
    {
        public ValidationResult resultados { get; private set; }

        public abstract void AssineRegrasCadastro();

        public abstract void AssineRegrasAtualizacao();

        public abstract void AssineRegrasExclusao();

        public virtual void Valide(TObjeto objeto)
        {
            resultados = Validate(objeto);
        }

        public virtual void AssegureNenhumaInconsistencia()
        {
            if (!resultados.IsValid)
            {
                throw new ArgumentException(JsonSerializer.Serialize(resultados.Errors));
            }
        }
    }
}
