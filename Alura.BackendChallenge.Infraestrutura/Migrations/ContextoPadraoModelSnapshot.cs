// <auto-generated />
using Alura.BackendChallenge.Infraestrutura;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Alura.BackendChallenge.Infraestrutura.Migrations
{
    [DbContext(typeof(ContextoPadrao))]
    partial class ContextoPadraoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Alura.BackendChallenge.Dominio.Objetos.VideoObj.Video", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(40)
                        .HasColumnType("varchar(40)")
                        .HasColumnName("VIDID");

                    b.Property<decimal>("Codigo")
                        .HasColumnType("numeric(6)")
                        .HasColumnName("VIDCODIGO");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)")
                        .HasColumnName("VIDDESCRICAO");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("VIDTITULO");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("varchar(120)")
                        .HasColumnName("VIDURL");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique()
                        .HasDatabaseName("IDX_IDVIDEO");

                    b.ToTable("VIDEOS");
                });
#pragma warning restore 612, 618
        }
    }
}
