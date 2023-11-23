using CrudWinFormsBancoMemoria;
using CrudWinFormsBancoMemoria.Models;
using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Infraestrutura.Repositorios
{
    public class RepositorioBD : IRepositorio
    {
        private readonly string stringConexao = ConfigurationManager.ConnectionStrings["PokemonDB"].ConnectionString;
        private readonly ConversaoBancoParaPokemon _conversao;

        public RepositorioBD(ConversaoBancoParaPokemon conversao)
        {
            _conversao = conversao;
        }

        public void Atualizar(Pokemon pokemon)
        {
            string textoComando = "UPDATE pokemons " +
                                  "SET nome = @nome, apelido = @apelido, nivel = @nivel, altura = @altura, shiny = @shiny, data_de_captura = @dataCaptura, tipo_principal = @tipoPrincipal, tipo_secundario = @tipoSecundario, foto = @foto " +
                                  "WHERE id = @id";

            using (SqlConnection conexao = new SqlConnection(stringConexao))
            {
                try
                {
                    conexao.Open();
                    SqlCommand comando = new SqlCommand(textoComando, conexao);
                    comando.Parameters.AddWithValue("@id", pokemon.Id);
                    comando.Parameters.AddWithValue("@nome", pokemon.Nome);
                    comando.Parameters.AddWithValue("apelido", pokemon.Apelido);
                    comando.Parameters.AddWithValue("@nivel", pokemon.Nivel);
                    comando.Parameters.AddWithValue("@altura", pokemon.Altura);
                    comando.Parameters.AddWithValue("@shiny", pokemon.Shiny);
                    comando.Parameters.AddWithValue("@dataCaptura", pokemon.DataDeCaptura);
                    comando.Parameters.AddWithValue("@tipoPrincipal", pokemon.TipoPrincipal.ToString());
                    comando.Parameters.AddWithValue("@tipoSecundario", pokemon.TipoSecundario.ToString());
                    if (pokemon.Foto == null) comando.Parameters.Add(@"foto", SqlDbType.VarChar).Value = DBNull.Value;
                    else comando.Parameters.Add("@foto", SqlDbType.VarChar).Value = pokemon.Foto;
                    comando.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao atualizar Pokemon do Banco.");
                }
                finally { conexao.Close(); }
            }
        }

        public void Criar(Pokemon novoPokemon)
        {
            string textoComando = "INSERT INTO pokemons (nome, apelido, nivel, altura, shiny, data_de_captura, tipo_principal, tipo_secundario, foto)" +
                                  "VALUES (@nome, @apelido, @nivel, @altura, @shiny, @dataCaptura, @tipoPrincipal, @tipoSecundario, @foto)";
            using (SqlConnection conexao = new SqlConnection(stringConexao))
            {
                try
                {
                    conexao.Open();
                    SqlCommand comando = new SqlCommand(textoComando, conexao);
                    comando.Parameters.AddWithValue("@nome", novoPokemon.Nome);
                    comando.Parameters.AddWithValue("apelido", novoPokemon.Apelido);
                    comando.Parameters.AddWithValue("@nivel", novoPokemon.Nivel);
                    comando.Parameters.AddWithValue("@altura", novoPokemon.Altura);
                    comando.Parameters.AddWithValue("@shiny", novoPokemon.Shiny);
                    comando.Parameters.AddWithValue("@dataCaptura", novoPokemon.DataDeCaptura);
                    comando.Parameters.AddWithValue("@tipoPrincipal", novoPokemon.TipoPrincipal.ToString());
                    comando.Parameters.AddWithValue("@tipoSecundario", novoPokemon.TipoSecundario.ToString());
                    if (novoPokemon.Foto == null) comando.Parameters.Add(@"foto", SqlDbType.VarChar).Value = DBNull.Value;
                    else comando.Parameters.Add("@foto", SqlDbType.VarChar).Value = novoPokemon.Foto;
                    comando.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao inserir Pokemon ao Banco.");
                }
                finally { conexao.Close(); }
            }
        }

        public Pokemon ObterPorId(int id)
        {
            Pokemon pokemon = new Pokemon();
            string textoComando = "SELECT * FROM Pokemon WHERE id = @id";
            using (SqlConnection conexao = new SqlConnection(stringConexao))
            {
                try
                {
                    conexao.Open();
                    SqlCommand comando = new SqlCommand(textoComando, conexao);
                    comando.Parameters.AddWithValue("@id", pokemon.Id);
                    SqlDataReader dr = comando.ExecuteReader();
                    pokemon = _conversao.AtribuiLinhaAoPokemon(dr, pokemon);
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao obter Pokemon pelo id do Banco.");
                }
                finally { conexao.Close(); }
            }
            return pokemon;
        }

        public List<Pokemon> ObterTodos()
        {
            List<Pokemon> listaPokemon = new List<Pokemon>();
            string textoComando = "SELECT * FROM pokemons";
            using (SqlConnection conexao = new SqlConnection(stringConexao))
            {
                try
                {
                    conexao.Open();
                    SqlCommand comando = new SqlCommand(textoComando, conexao);
                    SqlDataReader dr = comando.ExecuteReader();
                    while (dr.Read())
                    {
                        Pokemon pokemon = new Pokemon();
                        listaPokemon.Add(_conversao.AtribuiLinhaAoPokemon(dr, pokemon));
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao obter os Pokemon do Banco.");
                }
                finally { conexao.Close(); }
            }
            return listaPokemon;
        }

        public void Remover(Pokemon pokemon)
        {
            string textoComando = "DELETE FROM pokemons " +
                                  "WHERE id=@id";
            using (SqlConnection conexao = new SqlConnection(stringConexao))
            {
                try
                {
                    conexao.Open();
                    SqlCommand comando = new SqlCommand(textoComando, conexao);
                    comando.Parameters.AddWithValue("@id", pokemon.Id);
                    comando.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao remover Pokemon ao Banco.");
                }
                finally { conexao.Close(); }
            }
        }
    }
}
