using CrudWinFormsBancoMemoria.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace CrudWinFormsBancoMemoria
{
    public partial class GerenciadorDePokemons : Form
    {
        private List<Pokemon> listaPokemons = new List<Pokemon>();

        public GerenciadorDePokemons()
        {
            InitializeComponent();
            pokemonDataGriedView.DataSource = null;
        }

        private void AoClicarNoBotaoAdicionar(object sender, EventArgs e)
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
            novoPokemon.Id = listaPokemons.Count;
            novoPokemon.DataDeCaptura = Convert.ToDateTime(novoPokemon.DataDeCaptura.ToShortDateString());
            listaPokemons.Add(novoPokemon);
            AtualizandoDataGridView();
        }

        public void AtualizandoDataGridView()
        {
            pokemonDataGriedView.DataSource = typeof(List<Pokemon>);
            pokemonDataGriedView.DataSource = listaPokemons;
        }


    }
}