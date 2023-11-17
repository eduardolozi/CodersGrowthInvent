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
            try
            {
                BancoDeDados.ConfiguracaoDaMigracao();
            } catch (Exception ex)
            {
                ex.ToString(); 
            }
            ApplicationConfiguration.Initialize();
            Application.Run(new GerenciadorDePokemons());
        }
    }
}