using CrudWinFormsBancoMemoria.Migracoes;
using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;

namespace CrudWinFormsBancoMemoria
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var serviceProvider = CreateServices())
            using (var scope = serviceProvider.CreateScope())
            {
                UpdateDatabase(scope.ServiceProvider);
            }
            ApplicationConfiguration.Initialize();
            Application.Run(new GerenciadorDePokemons());
        }

        private static ServiceProvider CreateServices()
        {
            return new ServiceCollection()
                .AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    .AddSqlServer()
                    .WithGlobalConnectionString(@"Data Source=DESKTOP-O3F8OCR;Initial Catalog=CodersGrowth;Persist Security Info=True;User ID=sa;Password=sap@123")
                    .ScanIn(typeof(AddPokemonTable).Assembly).For.Migrations())
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                .BuildServiceProvider(false);
        }

        private static void UpdateDatabase(IServiceProvider serviceProvider)
        {
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
            runner.MigrateUp();
        }
    }
}