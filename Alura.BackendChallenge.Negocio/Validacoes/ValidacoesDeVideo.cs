using System;
using Alura.BackendChallenge.Compartilhado.Globalizacoes;
using Alura.BackendChallenge.Interfaces.InterfacesDeRepositorio;
using FluentValidation;

namespace Alura.BackendChallenge.Dominio.Objetos.VideoObj
{
    /// <summary>
    /// Classe para validações de <see cref="Video"/>
    /// </summary>
    public class ValidacoesDeVideo : ValidacoesObjetoComCodigoNumerico<Video>
    {
        private IRepositorioVideo _repositorio;

        public ValidacoesDeVideo(IRepositorioVideo repositorio)
        {
            _repositorio = repositorio;
        }

        #region VALIDACOES DE PROPRIEDADES

        #region TITULO

        public void AssineRegraTituloObrigatorio()
        {
            RuleFor(x => x.Titulo)
                .NotNull()
                .NotEmpty()
                .WithMessage(GlobalizacoesDeValidacao.TituloObrigatorio);
        }

        public void AssineRegraTituloTamanhoMaximo()
        {
            RuleFor(x => x.Titulo)
                .MaximumLength(Video.TAMANHO_MAXIMO_TITULO)
                .WithMessage(GlobalizacoesDeValidacao.TituloTamanhoMaximo);
        }

        #endregion

        #region DESCRICAO

        public void AssineRegraDescricaoObrigatoria()
        {
            RuleFor(x => x.Descricao)
                .NotNull()
                .NotEmpty()
                .WithMessage(GlobalizacoesDeValidacao.DescricaoObrigatoria);
        }

        public void AssineRegraDescricaoTamanhoMaximo()
        {
            RuleFor(x => x.Descricao)
                .MaximumLength(Video.TAMANHO_MAXIMO_DESCRICAO)
                .WithMessage(GlobalizacoesDeValidacao.DescricaoTamanhoMaximo);
        }

        #endregion

        #region URL

        public void AssineRegraUrlObrigatoria()
        {
            RuleFor(x => x.Url)
                .NotNull()
                .NotEmpty()
                .WithMessage(GlobalizacoesDeValidacao.UrlObrigatorio);
        }

        public void AssineRegraUrlTamanhoMaximo()
        {
            RuleFor(x => x.Url)
                .MaximumLength(Video.TAMANHO_MAXIMO_URL)
                .WithMessage(GlobalizacoesDeValidacao.UrlTamanhoMaximo);
        }

        public void AssineRegraUrlValida()
        {
            RuleFor(x => x.Url)
                .Must(LinkValido)
                .WithMessage(GlobalizacoesDeValidacao.UrlInvalido);
        }

        #endregion

        #endregion

        #region VALIDACOES DE BANCO

        public void AssineRegraVideoCadastrado()
        {
            RuleFor(x => x.Codigo)
                .Must(EstaCadastrado)
                .WithMessage(GlobalizacoesDeValidacao.VideoNaoCadastrado);
        }

        public void AssineRegraVideoNaoCadastrado()
        {
            RuleFor(x => x.Codigo)
                .Must(NaoEstaCadastrado)
                .WithMessage(GlobalizacoesDeValidacao.VideoCadastrado);
        }

        #endregion

        #region FLUXOS DE VALIDAÇÃO

        public override void AssineRegrasCadastro()
        {
            AssineRegrasComunsAoCadastroEAtualizacao();
            AssineRegraVideoNaoCadastrado();
        }

        public override void AssineRegrasAtualizacao()
        {
            AssineRegrasComunsAoCadastroEAtualizacao();
            AssineRegraVideoCadastrado();
        }

        public override void AssineRegrasExclusao()
        {
            AssineRegraVideoCadastrado();
        }

        #endregion

        #region METODOS PRIVADOS

        private void AssineRegrasComunsAoCadastroEAtualizacao()
        {
            AssineRegraCodigoObrigatorio();
            AssineRegraCodigoValido();
            AssineRegraTituloObrigatorio();
            AssineRegraTituloTamanhoMaximo();
            AssineRegraDescricaoObrigatoria();
            AssineRegraDescricaoTamanhoMaximo();
            AssineRegraUrlObrigatoria();
            AssineRegraUrlTamanhoMaximo();
            AssineRegraUrlValida();
        }

        private bool LinkValido(string link)
        {
            Uri outUri;

            return !string.IsNullOrWhiteSpace(link)
                ? Uri.TryCreate(link, UriKind.Absolute, out outUri)
                   && (outUri.Scheme == Uri.UriSchemeHttp || outUri.Scheme == Uri.UriSchemeHttps)
                : false;
        }

        private bool EstaCadastrado(int codigo)
        {
            return _repositorio.Consulte(codigo) != null;
        }

        private bool NaoEstaCadastrado(int codigo)
        {
            return !EstaCadastrado(codigo);
        }

        #endregion
    }
}
