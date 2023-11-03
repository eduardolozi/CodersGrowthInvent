using CrudWinFormsBancoMemoria.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace CrudWinFormsBancoMemoria
{
    public partial class GerenciadorDePokemons : Form
    {
        private List<Pokemon> listaPokemons = new List<Pokemon>() {
            new Pokemon {Id = 1, Nome = "Charmander", Apelido = "Tobias", Nivel = 12, DataDeCaptura = DateTime.Now, Altura = 0.60m, Shiny = true, TipoPrincipal = TipoPokemon.Fogo, TipoSecundario = null},
            new Pokemon {Id = 2, Nome = "Mewtwo", Apelido = "Tiringa", Nivel = 70, DataDeCaptura = DateTime.Now, Altura = 2.0m, Shiny = false, TipoPrincipal = TipoPokemon.Psiquico, TipoSecundario = null},
            new Pokemon {Id = 3, Nome = "Zubat", Apelido = "Dracula", Nivel = 7, DataDeCaptura = DateTime.Now, Altura = 0.80m, Shiny = false, TipoPrincipal = TipoPokemon.Veneno, TipoSecundario = TipoPokemon.Voador},
        };

        public GerenciadorDePokemons()
        {
            InitializeComponent();
        }

        private void GerenciadorDePokemons_Load(object sender, EventArgs e)
        {
            Criacao_DataGriedView();
        }

        private void Criacao_DataGriedView()
        {
            pokemonDataGriedView.DataSource = listaPokemons;
        }

        private void btnCriar_Click(object sender, EventArgs e)
        {
            var formCadastro = new CadastroPokemon();
            formCadastro.ShowDialog();
            if (formCadastro.DialogResult == DialogResult.OK)
            {
                SalvarPokemonCadastradoNaLista(formCadastro.novoPokemon);
                formCadastro.Dispose();
            }
        }

        private void SalvarPokemonCadastradoNaLista(Pokemon novoPokemon)
        {
            novoPokemon.Id = listaPokemons.Count + 1;
            listaPokemons.Add(novoPokemon);
            refresh_dataGridView();
        }

        public void refresh_dataGridView()
        {
            pokemonDataGriedView.DataSource = typeof(List<Pokemon>);
            pokemonDataGriedView.DataSource = listaPokemons;
        }

       
    }
}