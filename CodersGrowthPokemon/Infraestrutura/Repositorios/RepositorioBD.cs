using CrudWinFormsBancoMemoria.Models;
using Infraestrutura.Conversores;
using Infraestrutura.MensagensDeErro;
using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Infraestrutura.Repositorios
{
    public class RepositorioBD : IRepositorio
    {
        private readonly string StringDeConexao = ConfigurationManager.ConnectionStrings["PokemonDB"].ConnectionString;
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
            using (SqlConnection conexao = new SqlConnection(StringDeConexao))
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
                    comando.Parameters.Add("@tipoSecundario", SqlDbType.VarChar).Value = (pokemon.TipoSecundario == null) ? DBNull.Value : pokemon.TipoSecundario.ToString();
                    if (pokemon.Foto == null) comando.Parameters.Add(@"foto", SqlDbType.VarChar).Value = DBNull.Value;
                    else comando.Parameters.Add("@foto", SqlDbType.VarChar).Value = pokemon.Foto;
                    comando.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception(MensagensDeErroRepositorio.MENSAGEM_DE_ERRO_ATUALIZACAO) ;
                }
                finally { conexao.Close(); }
            }
        }

        public void Criar(Pokemon novoPokemon)
        {
            string textoComando = "INSERT INTO pokemons (nome, apelido, nivel, altura, shiny, data_de_captura, tipo_principal, tipo_secundario, foto) " +
                                  "OUTPUT INSERTED.ID " +
                                  "VALUES (@nome, @apelido, @nivel, @altura, @shiny, @dataCaptura, @tipoPrincipal, @tipoSecundario, @foto)";
            using (SqlConnection conexao = new SqlConnection(StringDeConexao))
            {
                try
                {
                    conexao.Open();
                    using(SqlCommand comando = new SqlCommand(textoComando, conexao))
                    {
                        comando.Parameters.AddWithValue("@nome", novoPokemon.Nome);
                        comando.Parameters.AddWithValue("apelido", novoPokemon.Apelido);
                        comando.Parameters.AddWithValue("@nivel", novoPokemon.Nivel);
                        comando.Parameters.AddWithValue("@altura", novoPokemon.Altura);
                        comando.Parameters.AddWithValue("@shiny", novoPokemon.Shiny);
                        comando.Parameters.AddWithValue("@dataCaptura", novoPokemon.DataDeCaptura);
                        comando.Parameters.AddWithValue("@tipoPrincipal", novoPokemon.TipoPrincipal.ToString());
                        comando.Parameters.Add("@tipoSecundario", SqlDbType.VarChar).Value = (novoPokemon.TipoSecundario == null) ? DBNull.Value : novoPokemon.TipoSecundario.ToString();
                        if (novoPokemon.Foto == null) comando.Parameters.Add(@"foto", SqlDbType.VarChar).Value = DBNull.Value;
                        else comando.Parameters.Add("@foto", SqlDbType.VarChar).Value = novoPokemon.Foto;

                        int indice = Convert.ToInt32(comando.ExecuteScalar());
                        novoPokemon.Id = indice;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(MensagensDeErroRepositorio.MENSAGEM_DE_ERRO_CRIACAO);
                }
                finally { conexao.Close(); }
            }
        }

        public Pokemon ObterPorId(int id)
        {
            string textoComando = "SELECT * FROM pokemons WHERE id=@id";
            using (SqlConnection conexao = new SqlConnection(StringDeConexao))
            {
                try
                {
                    conexao.Open();
                    SqlCommand comando = new SqlCommand(textoComando, conexao);
                    comando.Parameters.AddWithValue("@id", id);
                    SqlDataReader dr = comando.ExecuteReader();
                    Pokemon pokemon = new();
                    while(dr.Read()) pokemon = _conversao.AtribuiLinhaAoPokemon(dr, pokemon);
                    return pokemon;
                }
                catch (Exception ex)
                {
                    throw new Exception(MensagensDeErroRepositorio.MENSAGEM_DE_ERRO_OBTER_POR_ID);
                }
                finally { conexao.Close(); }
            }
        }

        public List<Pokemon> ObterTodos(string? nome)
        {
            List<Pokemon> listaPokemon = new List<Pokemon>();
            string textoComando = (nome is null) ? "SELECT * FROM pokemons" : "SELECT * FROM pokemons WHERE nome LIKE '%' + @nome + '%'";
            using (SqlConnection conexao = new SqlConnection(StringDeConexao))
            {
                try
                {
                    conexao.Open();
                    SqlCommand comando = new SqlCommand(textoComando, conexao);
                    if (nome != null) comando.Parameters.AddWithValue("@nome", nome);
                    SqlDataReader dr = comando.ExecuteReader();
                    while (dr.Read())
                    {
                        Pokemon pokemon = new ();
                        listaPokemon.Add(_conversao.AtribuiLinhaAoPokemon(dr, pokemon));
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(MensagensDeErroRepositorio.MENSAGEM_DE_ERRO_OBTER_TODOS);
                }
                finally { conexao.Close(); }
            }
            return listaPokemon;
        }

        public void Remover(Pokemon pokemon)
        {
            string textoComando = "DELETE FROM pokemons " +
                                  "WHERE id=@id";
            using (SqlConnection conexao = new SqlConnection(StringDeConexao))
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
                    throw new Exception(MensagensDeErroRepositorio.MENSAGEM_DE_ERRO_REMOCAO);
                }
                finally { conexao.Close(); }
            }
        }
    }
}
