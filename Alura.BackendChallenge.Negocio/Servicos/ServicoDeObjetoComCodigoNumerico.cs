using System.Collections.Generic;
using Alura.BackendChallenge.Dominio.Objetos;
using Alura.BackendChallenge.Interfaces.InterfacesDeRepositorio;
using Alura.BackendChallenge.Interfaces.InterfacesDeServico;
using Alura.BackendChallenge.Interfaces.Modelos;
using Alura.BackendChallenge.Negocio.Conversores.Interfaces;

namespace Alura.BackendChallenge.Negocio.Servicos
{
    /// <summary>
    /// Interface de servico para objetos com código numérico.
    /// </summary>
    /// <typeparam name="TDto"><see cref="DtoBase"/></typeparam>
    /// <typeparam name="TObjeto"><see cref="ObjetoComCodigoNumerico"/></typeparam>
    public abstract class ServicoDeObjetoComCodigoNumerico<TDto, TObjeto> : IServicoDeObjetoComCodigoNumerico<TDto, TObjeto>
        where TDto : DtoBase
        where TObjeto : ObjetoComCodigoNumerico
    {
        private readonly IRepositorioObjetoComCodigoNumerico<TObjeto> _repositorio;

        /// <summary>
        /// Construtor padrão.
        /// </summary>
        /// <param name="repositorio">O repositório do contexto (via injeção de dependência).</param>
        public ServicoDeObjetoComCodigoNumerico(IRepositorioObjetoComCodigoNumerico<TObjeto> repositorio)
        {
            _repositorio = repositorio;
        }

        /// <summary>
        /// Cadastra uma nova ocorrência do conceito no contexto.
        /// </summary>
        /// <param name="dto">A instância a ser cadastrada.</param>
        public virtual void Cadastre(TDto dto)
        {
            var objeto = Conversor().Converta(dto);
            // Validar...
            _repositorio.Cadastre(objeto);
        }

        /// <summary>
        /// Consulte uma ocorrência do conceito por código.
        /// </summary>
        /// <param name="codigo">O código da ocorrência.</param>
        /// <returns>Uma instância do conceito.</returns>
        public virtual TDto Consulte(int codigo)
        {
            var objeto = _repositorio.Consulte(codigo);
            return Conversor().Converta(objeto);
        }

        /// <summary>
        /// Consulta todos os conceitos do contexto.
        /// </summary>
        /// <returns>Uma lista com os registros.</returns>
        public virtual IList<TDto> ConsulteLista()
        {
            var objetos = _repositorio.ConsulteLista();
            return Conversor().Converta(objetos);
        }

        /// <summary>
        /// Consulta uma lista parcial dos conceitos do contexto
        /// </summary>
        /// <param name="qtdeAPular">A quantidade de registros a ser pulada a partir do primeiro.</param>
        /// <param name="qtdeARetornar">A quantidade de registros a ser retornada.</param>
        public virtual IList<TDto> ConsulteLista(int qtdeAPular, int qtdeARetornar)
        {
            var objetos = _repositorio.ConsulteLista(qtdeAPular, qtdeARetornar);
            return Conversor().Converta(objetos);
        }

        /// <summary>
        /// Atualiza um registro do conceito já cadastrada no contexto.
        /// </summary>
        /// <param name="dto">Os novos valores (Exceto o código).</param>
        public virtual void Atualize(TDto dto)
        {
            var objeto = Conversor().ConvertaParaObjetoPersistido(_repositorio, dto);
            // Validar...
            _repositorio.Atualize(objeto);
        }

        /// <summary>
        /// Exlui um registro do contexto.
        /// </summary>
        /// <param name="codigo">O código do registro a ser excluído.</param>
        /// <returns>True se o objeto existir, False caso o contrário.</returns>
        public virtual bool Exclua(int codigo)
        {
            var objeto = _repositorio.Consulte(codigo);
            if (objeto != null)
            {
                _repositorio.Exclua(objeto);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Obtém a instância do conversor do conceito.
        /// </summary>
        /// <returns>Uma nova instância do conversor.</returns>
        protected abstract IConversor<TDto, TObjeto> Conversor();
    }
}
