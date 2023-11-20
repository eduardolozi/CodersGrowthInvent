using CrudWinFormsBancoMemoria.Models;
using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace CrudWinFormsBancoMemoria
{
    public class RepositorioBD : IRepositorio
    {
        private string stringConexao = ConfigurationManager.ConnectionStrings["PokemonDB"].ConnectionString;

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
                    comando.Parameters.AddWithValue("@nome", pokemon.Nome);
                    comando.Parameters.AddWithValue("apelido", pokemon.Apelido);
                    comando.Parameters.AddWithValue("@nivel", pokemon.Nivel);
                    comando.Parameters.AddWithValue("@altura", pokemon.Altura);
                    comando.Parameters.AddWithValue("@shiny", pokemon.Shiny);
                    comando.Parameters.AddWithValue("@dataCaptura", pokemon.DataDeCaptura);
                    comando.Parameters.AddWithValue("@tipoPrincipal", pokemon.TipoPrincipal.ToString());
                    comando.Parameters.AddWithValue("@tipoSecundario", pokemon.TipoSecundario.ToString());
                    comando.Parameters.AddWithValue("@foto", pokemon.Foto);
                    comando.Parameters.AddWithValue("@id", pokemon.Id);
                    comando.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
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
                    MessageBox.Show(ex.Message);
                }
                finally { conexao.Close(); }
            }
        }

        private Pokemon AtribuiLinhaAoPokemon(SqlDataReader dr, Pokemon pokemon)
        {
            pokemon.Id = Convert.ToInt32(dr["id"]);
            pokemon.Nome = dr["nome"].ToString();
            pokemon.Apelido = dr["apelido"].ToString();
            pokemon.Nivel = Convert.ToInt32(dr["nivel"]);
            pokemon.Altura = Convert.ToDecimal(dr["altura"]);
            pokemon.Shiny = Convert.ToBoolean(dr["shiny"]);
            pokemon.DataDeCaptura = Convert.ToDateTime(dr["data_de_captura"]);

            pokemon.TipoPrincipal = Enum.Parse<TipoPokemon>(dr["tipo_principal"].ToString());
            if (dr["tipo_secundario"].ToString() == "") pokemon.TipoSecundario = null;
            else pokemon.TipoSecundario = Enum.Parse<TipoPokemon>(dr["tipo_secundario"].ToString());

            if (dr["foto"].ToString() == "") pokemon.Foto = null;
            else pokemon.Foto = dr["foto"].ToString();

            return pokemon;
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
                    pokemon = AtribuiLinhaAoPokemon(dr, pokemon);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
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
                        listaPokemon.Add(AtribuiLinhaAoPokemon(dr, pokemon));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
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
                    MessageBox.Show(ex.Message);
                }
                finally { conexao.Close(); }
            }
        }
    }
}
