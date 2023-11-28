using CrudWinFormsBancoMemoria.Migracoes;
using FluentMigrator.Runner;
using Infraestrutura.MensagensDeErro;
using Infraestrutura.Repositorios;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Configuration;

namespace CrudWinFormsBancoMemoria
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            try
            {
                BancoDeDados.ConfiguracaoDaMigracao();
            } catch (Exception ex)
            {
                ex.ToString(); 
            }
            var builder = CriaHostBuilder();
            var servicesProvider = builder.Build().Services;
            var repositorio = servicesProvider.GetService<IRepositorio>();

            ApplicationConfiguration.Initialize();
            Application.Run(new GerenciadorDePokemons(repositorio));
        }

        static IHostBuilder CriaHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) => {
                    services.AddScoped<IRepositorio, RepositorioLinqToDb>();
                    services.AddScoped<ConversaoBancoParaPokemon>();
                });
        }
    }
}