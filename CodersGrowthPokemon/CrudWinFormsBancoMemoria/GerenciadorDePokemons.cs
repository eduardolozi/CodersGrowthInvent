using CrudWinFormsBancoMemoria.Models;
using Dominio.Validacoes;
using Infraestrutura.Repositorios;
using System.Data.Common;

namespace CrudWinFormsBancoMemoria
{
    public partial class GerenciadorDePokemons : Form
    {
        private readonly IRepositorio _repositorio;
        private readonly PokemonValidator _validacao = new();

        public GerenciadorDePokemons(IRepositorio repositorio)
        {
            InitializeComponent();
            _repositorio = repositorio;

            try
            {
                pokemonDataGriedView.DataSource = (_repositorio is Repositorio) ? null : _repositorio.ObterTodos(null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FormataDisplayDaData(object sender, EventArgs e)
        {
            const int COLUNA_DE_DATA = 6;
            pokemonDataGriedView.Columns[COLUNA_DE_DATA].DefaultCellStyle.Format = "dd/MM/yyyy";
        }

        private void AoClicarNoBotaoAdicionar(object sender, EventArgs e)
        {
            const string ADICAO_BEM_SUCEDIDA = "Pokemon adicionado com sucesso!";

            try
            {
                var formCadastro = new CadastroPokemon(_validacao);
                formCadastro.ShowDialog();
                if (formCadastro.DialogResult == DialogResult.OK)
                {
                    _repositorio.Criar(formCadastro.pokemon);
                    formCadastro.Dispose();
                    MessageBox.Show(ADICAO_BEM_SUCEDIDA);
                    AtualizandoDataGridView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void AtualizandoDataGridView()
        {
            try
            {
                pokemonDataGriedView.DataSource = null;
                pokemonDataGriedView.DataSource = _repositorio.ObterTodos(null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
            const int COLUNA_DE_IMAGEM = 9;

            try
            {
                if (pokemonDataGriedView.CurrentCell.ColumnIndex == COLUNA_DE_IMAGEM && this.pokemonDataGriedView.CurrentCell.Value != null)
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
            const int COLUNA_DE_IMAGEM = 9;
            const string CELULA_COM_FOTO = "Clique para ver";
            const string CELULA_SEM_FOTO = "Foto inválida";

            if (e.Value != null && e.ColumnIndex == COLUNA_DE_IMAGEM)
            {
                e.Value = CELULA_COM_FOTO;
            }
            else if (e.Value == null && e.ColumnIndex == COLUNA_DE_IMAGEM)
            {
                e.Value = CELULA_SEM_FOTO;
            }
        }

        private void AoClicarNoBotaoEditar(object sender, EventArgs e)
        {
            const string EDICAO_BEM_SUCEDIDA = "Pokemon editado com sucesso!";
            const string NENHUMA_LINHA_SELECIONADA = "Selecione uma linha.";
            const string MAIS_DE_UMA_LINHA_SELECIONADA = "Selecione apenas uma linha.";
            try
            {
                if (pokemonDataGriedView.SelectedRows.Count == 1)
                {
                    Pokemon pokemonEditado;
                    var index = (int)pokemonDataGriedView.CurrentRow.Cells[0].Value;
                    pokemonEditado = _repositorio.ObterPorId(index);

                    var formCadastro = new CadastroPokemon(_validacao, pokemonEditado);
                    formCadastro.ShowDialog();
                    if (formCadastro.DialogResult == DialogResult.OK)
                    {
                        _repositorio.Atualizar(pokemonEditado);
                        formCadastro.Dispose();
                        MessageBox.Show(EDICAO_BEM_SUCEDIDA);
                        AtualizandoDataGridView();
                    }
                }
                else if (pokemonDataGriedView.SelectedRows.Count > 1)
                {
                    MessageBox.Show(MAIS_DE_UMA_LINHA_SELECIONADA);
                }
                else MessageBox.Show(NENHUMA_LINHA_SELECIONADA);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AoClicarBotaoApagar(object sender, EventArgs e)
        {
            const int COLUNA_DE_INDICE = 0;
            const string REMOCAO_BEM_SUCEDIDA = "Pokemon removido com sucesso!";
            const string NENHUMA_LINHA_SELECIONADA = "Selecione uma linha.";
            const string MAIS_DE_UMA_LINHA_SELECIONADA = "Selecione apenas uma linha.";
            const string NOME_MESSAGE_BOX_REMOCAO = "Remoção de Pokemon";
            const string MENSAGEM_DE_REMOCAO = $"Tem certeza que deseja remover o pokemon?";

            try
            {
                if (pokemonDataGriedView.SelectedRows.Count == 1)
                {
                    Pokemon pokemonASerExcluido = (Pokemon)pokemonDataGriedView.SelectedRows[COLUNA_DE_INDICE].DataBoundItem;
                    var confirmarRemocao = MessageBox.Show(MENSAGEM_DE_REMOCAO, NOME_MESSAGE_BOX_REMOCAO, MessageBoxButtons.YesNo);
                    if (confirmarRemocao == DialogResult.Yes)
                    {
                        _repositorio.Remover(pokemonASerExcluido);
                        MessageBox.Show(REMOCAO_BEM_SUCEDIDA);
                        AtualizandoDataGridView();
                    }
                }
                else if (pokemonDataGriedView.SelectedRows.Count > 1)
                {
                    MessageBox.Show(MAIS_DE_UMA_LINHA_SELECIONADA);
                }
                else MessageBox.Show(NENHUMA_LINHA_SELECIONADA);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}