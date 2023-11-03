using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudWinFormsBancoMemoria.Models
{
    public class Pokemon
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Apelido { get; set; }

        public int Nivel { get; set; }

        public decimal Altura { get; set; }

        public Boolean Shiny { get; set; }

        public DateTime DataDeCaptura { get; set; }

        public TipoPokemon TipoPrincipal { get; set; }

        public TipoPokemon? TipoSecundario { get; set; }

        public Image? Foto { get; set; }
        
    }
}
