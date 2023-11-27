using CrudWinFormsBancoMemoria.Migracoes;
using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudWinFormsBancoMemoria
{
    public class BancoDeDados
    {
        private static readonly string StringDeConexao = ConfigurationManager.ConnectionStrings["PokemonDB"].ConnectionString;

        public static void ConfiguracaoDaMigracao()
        {
            using (var serviceProvider = CriacaoDeServicos())
            using (var scope = serviceProvider.CreateScope())
            {
                AtualizarBancoDeDados(scope.ServiceProvider);
            }
        }

        private static ServiceProvider CriacaoDeServicos()
        {
            return new ServiceCollection()
                .AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    .AddSqlServer()
                    .WithGlobalConnectionString(StringDeConexao)
                    .ScanIn(typeof(AddPokemonTable).Assembly).For.Migrations())
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                .BuildServiceProvider(false);
        }

        private static void AtualizarBancoDeDados(IServiceProvider serviceProvider)
        {
            var inicializador = serviceProvider.GetRequiredService<IMigrationRunner>();
            inicializador.MigrateUp();
        }
    }
}
