using CrudWinFormsBancoMemoria.Models;
using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace CrudWinFormsBancoMemoria
{
    public class RepositorioBD : IRepositorio
    {
        private string stringConexao = ConfigurationManager.ConnectionStrings["PokemonDB"].ConnectionString;
        private List<Pokemon> listaDePokemon = ListaSingleton.Instance;

        private SqlConnection CriaConexao()
        {
            SqlConnection conexao = new SqlConnection(stringConexao);
            return conexao;
        }

        public void Atualizar(Pokemon pokemon)
        {
            string textoComando = "";
            using(SqlConnection conexao = new SqlConnection(stringConexao))
            {
                try
                {
                    conexao.Open();
                    SqlCommand comando = new SqlCommand(textoComando, conexao);
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
            string textoComando = "";
            using (SqlConnection conexao = new SqlConnection(stringConexao))
            {
                try
                {
                    conexao.Open();
                    SqlCommand comando = new SqlCommand(textoComando, conexao);
                    comando.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally { conexao.Close(); }
            }
        }

        public Pokemon ObterPorId(int id)
        {
            string textoComando = "SELECT * FROM Pokemon WHERE id = @id";
            using (SqlConnection conexao = new SqlConnection(stringConexao))
            {
                SqlCommand comando = new SqlCommand(textoComando, conexao);
                comando.Parameters.Add("@id", SqlDbType.Int);
                comando.Parameters["@id"].Value = id;
                try
                {
                    conexao.Open();
                    SqlDataReader dr = comando.ExecuteReader();
                    Pokemon pokemon = new Pokemon();
                    while(dr.Read())
                    {
                        pokemon.Id = Convert.ToInt32(dr[0]);
                        pokemon.Nome = dr[1].ToString();
                        pokemon.Apelido = dr[2].ToString();
                        pokemon.Nivel = Convert.ToInt32(dr[3]);
                        pokemon.Altura = Convert.ToDecimal(dr[4]);
                        pokemon.Shiny = Convert.ToBoolean(dr[5]);
                        pokemon.DataDeCaptura = Convert.ToDateTime(dr[6]);
                        pokemon.TipoPrincipal = Enum.Parse<Pokemon>(dr[7]);
                        pokemon.TipoSecundario = ;
                        pokemon.Foto = ;
                        listaDePokemon.Add();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally { conexao.Close(); }
            }

            return null;
        }

        public List<Pokemon> ObterTodos()
        {
            string textoComando = "SELECT * FROM Pokemon";
            using (SqlConnection conexao = new SqlConnection(stringConexao))
            {
                try
                {
                    conexao.Open();
                    SqlCommand comando = new SqlCommand(textoComando, conexao);
                    SqlDataReader dr = comando.ExecuteReader();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally { conexao.Close(); }
            }

            return null;
        }

        public void Remover(Pokemon pokemon)
        {
            string textoComando = "";
            using (SqlConnection conexao = new SqlConnection(stringConexao))
            {
                try
                {
                    conexao.Open();
                    SqlCommand comando = new SqlCommand(textoComando, conexao);
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
