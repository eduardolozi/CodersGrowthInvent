using CrudWinFormsBancoMemoria.Models;
using Dominio.Validacoes;
using Infraestrutura.Repositorios;

namespace CrudWinFormsBancoMemoria
{
    public partial class GerenciadorDePokemons : Form
    {
        private IRepositorio _repositorio;
        private PokemonValidator _validacao = new PokemonValidator();

        public GerenciadorDePokemons(IRepositorio repositorio)
        {
            InitializeComponent();
            _repositorio = repositorio;
            pokemonDataGriedView.DataSource = _repositorio.ObterTodos();
        }

        private void AoClicarNoBotaoAdicionar(object sender, EventArgs e)
        {
            var formCadastro = new CadastroPokemon(_validacao);
            formCadastro.ShowDialog();
            if (formCadastro.DialogResult == DialogResult.OK)
            {
                _repositorio.Criar(formCadastro.pokemon);
                formCadastro.Dispose();
                AtualizandoDataGridView();
            }
        }

        public void AtualizandoDataGridView()
        {
            pokemonDataGriedView.DataSource = null;
            pokemonDataGriedView.DataSource = _repositorio.ObterTodos();
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
            try
            {
                if (pokemonDataGriedView.CurrentCell.ColumnIndex == 9 && this.pokemonDataGriedView.CurrentCell.Value != null)
                {
                    var cedula = this.pokemonDataGriedView.CurrentCell.Value.ToString();
                    ConverteBytesParaImagem(cedula);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void FormatandoAsCedulasDeFoto(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null && e.ColumnIndex == 9)
            {
                e.Value = "Clique para ver";
            }
            else if (e.Value == null && e.ColumnIndex == 9)
            {
                e.Value = "Foto inválida";
            }
        }

        private void AoClicarNoBotaoEditar(object sender, EventArgs e)
        {
            if (pokemonDataGriedView.SelectedRows.Count == 1)
            {
                Pokemon pokemonEditado;
                pokemonEditado = (Pokemon)pokemonDataGriedView.CurrentRow.DataBoundItem;

                var formCadastro = new CadastroPokemon(_validacao, pokemonEditado);
                formCadastro.ShowDialog();
                if (formCadastro.DialogResult == DialogResult.OK)
                {
                    _repositorio.Atualizar(pokemonEditado);
                    formCadastro.Dispose();
                    AtualizandoDataGridView();
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
                var confirmarRemocao = MessageBox.Show($@"Tem certeza que deseja remover o {pokemonASerExcluido.Nome}?", "Remoção concluida!", MessageBoxButtons.YesNo);
                if (confirmarRemocao == DialogResult.Yes)
                {
                    _repositorio.Remover(pokemonASerExcluido);
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