using CrudWinFormsBancoMemoria.Models;

namespace CrudWinFormsBancoMemoria
{
    public partial class Form1 : Form
    {
        private List<Pokemon> listaPokemons = new List<Pokemon>() { 
            new Pokemon {Id = 1, Nome = "Charmander", Apelido = "Tobias", Nivel = 12, DataDeCaptura = DateTime.Now, Altura = 0.60m, Shiny = true, TipoPrincipal = TipoPokemon.Fogo, TipoSecundario = null},
            new Pokemon {Id = 2, Nome = "Mewtwo", Apelido = "Tiringa", Nivel = 70, DataDeCaptura = DateTime.Now, Altura = 2.0m, Shiny = false, TipoPrincipal = TipoPokemon.Psiquico, TipoSecundario = null},
            new Pokemon {Id = 3, Nome = "Zubat", Apelido = "Dracula", Nivel = 7, DataDeCaptura = DateTime.Now, Altura = 0.80m, Shiny = false, TipoPrincipal = TipoPokemon.Veneno, TipoSecundario = TipoPokemon.Voador},
        };

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Criacao_DataGriedView();
        }

        private void Criacao_DataGriedView()
        {
            //var dados = from pokemon in listaPokemons
            //            select new { pokemon.Id, pokemon.Nome, pokemon.Apelido, pokemon.Nivel, pokemon.DataDeCaptura, pokemon.Altura, pokemon.Shiny, pokemon.TipoPrincipal, pokemon.TipoSecundario };
            
            pokemonDataGriedView.DataSource = listaPokemons;
        }

    }
}