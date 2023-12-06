using CrudWinFormsBancoMemoria.Models;
using Infraestrutura.MensagensDeErro;
using LinqToDB;
using System.Configuration;
using System.Linq;

namespace Infraestrutura.Repositorios
{
    public class RepositorioLinqToDb : IRepositorio
    {
        private readonly string StringDeConexao = ConfigurationManager.ConnectionStrings["PokemonDB"].ConnectionString;
        private DataContext CriaConexao()
        {
            return new DataContext(new DataOptions().UseSqlServer(StringDeConexao));
        }

        public List<Pokemon> ObterTodos()
        {
            try
            {
                using (var db = CriaConexao())
                {
                    return db.GetTable<Pokemon>().ToList();
                }
            }
            catch (Exception)
            {
                throw new Exception(MensagensDeErroRepositorio.MENSAGEM_DE_ERRO_OBTER_TODOS);
            }
        }

        public Pokemon ObterPorId(int id)
        {
            try
            {
                using (var db = CriaConexao())
                {
                    return (from p in ObterTodos()
                            where p.Id == id
                            select p).First();
                }
            }
            catch (Exception)
            {
                throw new Exception(MensagensDeErroRepositorio.MENSAGEM_DE_ERRO_OBTER_POR_ID);
            }
        }

        public void Remover(Pokemon pokemon)
        {
            try
            {
                using (var db = CriaConexao())
                {
                    db.Delete(pokemon);
                }
            }
            catch (Exception)
            {
                throw new Exception(MensagensDeErroRepositorio.MENSAGEM_DE_ERRO_REMOCAO);
            }
        }

        public void Criar(Pokemon novoPokemon)
        {
            try
            {
                using (var db = CriaConexao())
                {
                    db.Insert(novoPokemon);
                }
            }
            catch (Exception)
            {
                throw new Exception(MensagensDeErroRepositorio.MENSAGEM_DE_ERRO_CRIACAO);
            }
        }

        public void Atualizar(Pokemon pokemon)
        {
            try
            {
                using (var db = CriaConexao())
                {
                    db.Update(pokemon);
                }
            }
            catch (Exception)
            {
                throw new Exception(MensagensDeErroRepositorio.MENSAGEM_DE_ERRO_ATUALIZACAO);
            }
        }
    }
}
