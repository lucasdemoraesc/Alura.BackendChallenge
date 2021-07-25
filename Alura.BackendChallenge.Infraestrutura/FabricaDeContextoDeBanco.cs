using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Alura.BackendChallenge.Infraestrutura
{
    /// <summary>
    /// Fabrica de contexto para o EF Core.
    /// Utiliza a variável ASPNETCORE_ENVIRONMENT para definir qual arquivo de configuração usar.
    /// </summary>
    public class FabricaDeContextoDeBanco : IDesignTimeDbContextFactory<ContextoPadrao>
    {
        public ContextoPadrao CreateDbContext(string[] args)
        {
            string ambiente = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            IConfiguration configuracao = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{ambiente}.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            string stringDeConexao = configuracao.GetConnectionString(nameof(ContextoPadrao));

            var builder = new DbContextOptionsBuilder<ContextoPadrao>();
            builder.UseSqlServer(stringDeConexao, opcoes =>
                opcoes.MigrationsAssembly("Alura.BackendChallenge.Infraestrutura"));

            return new ContextoPadrao(builder.Options);
        }
    }
}
