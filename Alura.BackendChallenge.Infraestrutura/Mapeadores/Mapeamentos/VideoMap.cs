using Alura.BackendChallenge.Dominio.Objetos;
using Alura.BackendChallenge.Dominio.Objetos.VideoObj;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Alura.BackendChallenge.Infraestrutura.Mapeadores.Mapeamentos
{
    internal class VideoMap : IEntityTypeConfiguration<Video>
    {
        private const string NOME_TABELA = "VIDEOS";

        public void Configure(EntityTypeBuilder<Video> builder)
        {
            builder.ToTable(NOME_TABELA);
            builder.HasKey(x => x.Id);

            #region ID

            builder.Property(x => x.Id)
                .HasColumnName("VIDID")
                .HasColumnType("varchar(40)")
                .HasMaxLength(40)
                .IsRequired();

            builder.HasIndex(x => x.Id)
                .HasDatabaseName("IDX_IDVIDEO")
                .IsUnique();

            #endregion

            #region CODIGO

            builder.Property(x => x.Codigo)
                .HasColumnName("VIDCODIGO")
                .HasColumnType(string.Format("numeric({0})", ObjetoComCodigoNumerico.TAMANHO_MAXIMO_CODIGO))
                //.ValueGeneratedOnAdd()
                //.HasValueGenerator<UtilitarioGeradorDeCodigo<Video>>()
                .IsRequired();

            builder.HasIndex(x => x.Codigo)
                .HasDatabaseName("IDX_CODIGOVIDEO")
                .IsUnique();

            #endregion

            #region TITULO

            builder.Property(x => x.Titulo)
                .HasColumnName("VIDTITULO")
                .HasColumnType(string.Format("varchar({0})", Video.TAMANHO_MAXIMO_TITULO))
                .HasMaxLength(Video.TAMANHO_MAXIMO_TITULO)
                .IsRequired();

            #endregion

            #region DESCRICAO

            builder.Property(x => x.Descricao)
                .HasColumnName("VIDDESCRICAO")
                .HasColumnType(string.Format("varchar({0})", Video.TAMANHO_MAXIMO_DESCRICAO))
                .HasMaxLength(Video.TAMANHO_MAXIMO_DESCRICAO)
                .IsRequired();

            #endregion

            #region URL

            builder.Property(x => x.Url)
                .HasColumnName("VIDURL")
                .HasColumnType(string.Format("varchar({0})", Video.TAMANHO_MAXIMO_URL))
                .HasMaxLength(Video.TAMANHO_MAXIMO_URL)
                .IsRequired();

            #endregion
        }
    }
}
