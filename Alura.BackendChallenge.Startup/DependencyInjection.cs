using Alura.BackendChallenge.Infraestrutura;
using Alura.BackendChallenge.Infraestrutura.Mapeadores.Repositorios;
using Alura.BackendChallenge.Interfaces.InterfacesDeRepositorio;
using Alura.BackendChallenge.Interfaces.InterfacesDeServico;
using Alura.BackendChallenge.Negocio.Servicos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Alura.BackendChallenge.Startup
{
    /// <summary>
    /// Classe para a resolução de depêndencias na aplicação.
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Método de extênsão para a configuração de serviços da aplicação.
        /// </summary>
        /// <param name="servicos">A <see cref="IServiceCollection"/> da aplicação.</param>
        /// <param name="configuracao">A <see cref="IConfiguration"/> da aplicação.</param>
        public static void AddResolucaoDeDependencia(this IServiceCollection servicos, IConfiguration configuracao)
        {
            servicos.AddDbContext<ContextoPadrao>(options =>
                options.UseSqlServer(configuracao.GetConnectionString(nameof(ContextoPadrao))));

            servicos.AddTransient<IRepositorioVideo, RepositorioVideo>();
            servicos.AddTransient<IServicoDeVideo, ServicoDeVideo>();
        }
    }
}
