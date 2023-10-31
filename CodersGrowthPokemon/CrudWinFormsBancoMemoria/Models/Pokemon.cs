using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudWinFormsBancoMemoria.Models
{
    public class Pokemon
    {
        private int _id { get; set; }

        private string _nome { get; set; }

        private string _apelido { get; set; }

        private int _nivel { get; set; }

        private Boolean _evolucao { get; set; }

        private decimal _altura { get; set; }

        private Boolean _favorito { get; set; }

        private DateTime _dataDeCaptura { get; set; }

        private List<TipoPokemon> _tipo { get; set; }

        public Pokemon()
        {

        }

        public Pokemon(int id, string nome, string apelido, int nivel, bool evolucao, decimal altura, bool favorito, DateTime dataDeCaptura, List<TipoPokemon> tipo)
        {
            _id = id;
            _nome = nome;
            _apelido = apelido;
            _nivel = nivel;
            _evolucao = evolucao;
            _altura = altura;
            _favorito = favorito;
            _dataDeCaptura = dataDeCaptura;
            _tipo = tipo;
        }
    }
}
