using CrudWinFormsBancoMemoria.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace CrudWinFormsBancoMemoria
{
    public partial class GerenciadorDePokemons : Form
    {
        private ListaSingleton<Pokemon> listaDePokemons = ListaSingleton<Pokemon>.Instance;

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
                SalvarPokemonCadastradoNaLista(formCadastro.pokemon);
                formCadastro.Dispose();
            }
        }

        private void SalvarPokemonCadastradoNaLista(Pokemon novoPokemon)
        {
            novoPokemon.Id = ListaSingleton<Pokemon>.GeraId();
            novoPokemon.DataDeCaptura = Convert.ToDateTime(novoPokemon.DataDeCaptura.ToShortDateString());

            listaDePokemons.Add(novoPokemon);
            AtualizandoDataGridView();
        }

        public void AtualizandoDataGridView()
        {
            pokemonDataGriedView.DataSource = typeof(ListaSingleton<Pokemon>);
            pokemonDataGriedView.DataSource = listaDePokemons;
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

        private void SalvarPokemonEditadoNaLista(Pokemon pokemonEditado)
        {
            int index = listaDePokemons.FindIndex(p => p.Equals(pokemonEditado));
            listaDePokemons[index] = pokemonEditado;
            AtualizandoDataGridView();
        }

        private void AoClicarNoBotaoEditar(object sender, EventArgs e)
        {
            if (pokemonDataGriedView.SelectedRows.Count == 1)
            {
                Pokemon pokemonEditado;
                pokemonEditado = (Pokemon)pokemonDataGriedView.CurrentRow.DataBoundItem;

                var formCadastro = new CadastroPokemon(pokemonEditado);
                formCadastro.ShowDialog();
                if (formCadastro.DialogResult == DialogResult.OK)
                {
                    SalvarPokemonEditadoNaLista(formCadastro.pokemon);
                    formCadastro.Dispose();
                }
            }
            else if (pokemonDataGriedView.SelectedRows.Count > 1)
            {
                MessageBox.Show("Selecione apenas uma linha.");
            }
            else MessageBox.Show("Selecione uma linha.");
        }

        private void AoClicarBotaoApagar(object sender, EventArgs e)
        {
            if (pokemonDataGriedView.SelectedRows.Count == 1)
            {
                
                Pokemon pokemonASerExcluido = (Pokemon)pokemonDataGriedView.SelectedRows[0].DataBoundItem;
                var confirmarRemocao = MessageBox.Show($@"Tem certeza que deseja remover o {pokemonASerExcluido.Nome}?", "Remoção concluida!" , MessageBoxButtons.YesNo);
                if (confirmarRemocao == DialogResult.Yes) {
                    int idRemovido = pokemonASerExcluido.Id;
                    listaDePokemons.Remove(pokemonASerExcluido);
                    listaDePokemons = ListaSingleton<Pokemon>.RedefineIdAposRemocao(listaDePokemons, idRemovido);
                    AtualizandoDataGridView();
                }
            }
            else if (pokemonDataGriedView.SelectedRows.Count > 1)
            {
                MessageBox.Show("Selecione apenas uma linha.");
            }
            else MessageBox.Show("Selecione uma linha.");
        }
    }
}