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
            novoPokemon.Id = listaPokemons.Count + 1;
            novoPokemon.DataDeCaptura = Convert.ToDateTime(novoPokemon.DataDeCaptura.ToShortDateString());

            listaPokemons.Add(novoPokemon);
            AtualizandoDataGridView();
        }

        public void AtualizandoDataGridView()
        {
            pokemonDataGriedView.DataSource = typeof(List<Pokemon>);
            pokemonDataGriedView.DataSource = listaPokemons;

        }

        private void ConverteBytesParaImagem(string cedula)
        {
            byte[] imagemEmBytes = Convert.FromBase64String(cedula);
            using (var ms = new MemoryStream(imagemEmBytes, 0, imagemEmBytes.Length))
            {
                Image foto = Image.FromStream(ms, true);
                var formImagem = new FormImagem();
                formImagem.Show();
                formImagem.fotoPokemon.Image = foto;
            }
        }

        private void AoClicarDuasVezesNaCelulaDeFoto(object sender, DataGridViewCellEventArgs e)
        {
            var cedula = this.pokemonDataGriedView.CurrentCell.Value.ToString();
            if (pokemonDataGriedView.CurrentCell.ColumnIndex == 9)
            {
                ConverteBytesParaImagem(cedula);
            }
        }

        private void FormatandoAsCedulasDeFoto(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null && e.ColumnIndex == 9)
            {
                e.Value = "Clique para ver";
            }
        }
    }
}