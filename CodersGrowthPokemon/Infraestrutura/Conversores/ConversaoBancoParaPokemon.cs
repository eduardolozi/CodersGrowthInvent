using CrudWinFormsBancoMemoria.Models;
using Dominio.Enums;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Conversores
{
    public class ConversaoBancoParaPokemon
    {
        private string ConverteValorParaString(object valor)
        {
            return valor.ToString();
        }

        private int ConverteValorParaInt(object valor)
        {
            return Convert.ToInt32(valor);
        }

        private decimal ConverteValorParaDecimal(object valor)
        {
            return Convert.ToDecimal(valor);
        }

        private bool ConverteValorParaBoolean(object valor)
        {
            return Convert.ToBoolean(valor);
        }

        private DateTime ConverteValorParaDateTime(object valor)
        {
            return Convert.ToDateTime(valor);
        }

        private TipoPokemonEnum ConverteValorParaTipoPokemon(object valor)
        {
            return Enum.Parse<TipoPokemonEnum>(valor.ToString());
        }
        public Pokemon AtribuiLinhaAoPokemon(SqlDataReader dr, Pokemon pokemon)
        {

            pokemon.Id = ConverteValorParaInt(dr["id"]);
            pokemon.Nome = ConverteValorParaString(dr["nome"]);
            pokemon.Apelido = ConverteValorParaString(dr["apelido"]);
            pokemon.Nivel = ConverteValorParaInt(dr["nivel"]);
            pokemon.Altura = ConverteValorParaDecimal(dr["altura"]);
            pokemon.Shiny = ConverteValorParaBoolean(dr["shiny"]);
            pokemon.DataDeCaptura = ConverteValorParaDateTime(dr["data_de_captura"]);
            pokemon.TipoPrincipal = ConverteValorParaTipoPokemon(dr["tipo_principal"]);
            if (dr["tipo_secundario"] == DBNull.Value) pokemon.TipoSecundario = null;
            else pokemon.TipoSecundario = ConverteValorParaTipoPokemon(dr["tipo_secundario"]);
            if (dr["foto"].ToString() == "") pokemon.Foto = null;
            else pokemon.Foto = ConverteValorParaString(dr["foto"]);

            return pokemon;
        }
    }
}
