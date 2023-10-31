using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudWinFormsBancoMemoria.Models
{
    public class Pokemon
    {
        private int Id { get; set; }

        private string Nome { get; set; }

        private string Apelido { get; set; }

        private int Nivel { get; set; }

        private decimal Altura { get; set; }

        private Boolean Shiny { get; set; }

        private DateTime DataDeCaptura { get; set; }

        private TipoPokemon TipoPrincipal { get; set; }

        private TipoPokemon? TipoSecundario { get; set; }
        
    }
}
