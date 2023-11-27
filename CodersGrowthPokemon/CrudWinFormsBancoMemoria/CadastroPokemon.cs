using CrudWinFormsBancoMemoria.Models;
using Dominio.Enums;
using Dominio.Validacoes;
using FluentValidation.Results;
using System.Data;
using System.Globalization;

namespace CrudWinFormsBancoMemoria
{
    public partial class CadastroPokemon : Form
    {
        public Pokemon? pokemon;
        private string? mensagemDeErro;
        private readonly PokemonValidator _Validacao;

        public CadastroPokemon(PokemonValidator validacao, Pokemon pokemonEditado = null)
        {
            pokemon = (pokemonEditado != null) ? pokemonEditado : null;
            _Validacao = validacao;
            InitializeComponent();
        }

        private void CarregandoCamposDoCadastro(object sender, EventArgs e)
        {
            const int NENHUM_TIPO_SELECIONADO = 0;
            const string TEXTO_PADRAO_COMBO_BOX = "--Selecionar--";
            const string FORMATO_DE_DATA = "dd/MM/yyyy";
            const string NOME_DO_FORMULARIO = "Atualização de Pokemon";
            const string TEXTO_BOTAO_ADICIONAR = "Atualizar Pokemon";

            dataPickerCaptura.Format = DateTimePickerFormat.Custom;
            dataPickerCaptura.CustomFormat = FORMATO_DE_DATA;

            comboBoxTipoPrincipal.Items.Insert(NENHUM_TIPO_SELECIONADO, TEXTO_PADRAO_COMBO_BOX);
            comboBoxTipoPrincipal.SelectedIndex = NENHUM_TIPO_SELECIONADO;
            comboBoxTipoPrincipal.Items.AddRange(Enum.GetValues(typeof(TipoPokemon)).Cast<Object>().ToArray());

            comboBoxTipoSecundario.Items.Insert(NENHUM_TIPO_SELECIONADO, TEXTO_PADRAO_COMBO_BOX);
            comboBoxTipoSecundario.SelectedIndex = NENHUM_TIPO_SELECIONADO;
            comboBoxTipoSecundario.Items.AddRange(Enum.GetValues(typeof(TipoPokemon)).Cast<Object>().ToArray());

            if (pokemon != null)
            { 
                txtNome.Text = pokemon.Nome;
                txtApelido.Text = pokemon.Apelido;
                txtNivel.Text = pokemon.Nivel.ToString();
                txtAltura.Text = pokemon.Altura.ToString(new CultureInfo("en-US"));
                dataPickerCaptura.Value = pokemon.DataDeCaptura;
                comboBoxTipoPrincipal.Text = pokemon.TipoPrincipal.ToString();
                if (pokemon.TipoSecundario == null) comboBoxTipoSecundario.Text = TEXTO_PADRAO_COMBO_BOX;
                else comboBoxTipoSecundario.Text = pokemon.TipoSecundario.ToString();
                checkBoxShiny.Checked = pokemon.Shiny;
                if (pokemon.Foto != null)
                {
                    byte[] imagemEmBytes = Convert.FromBase64String(pokemon.Foto);
                    using (var ms = new MemoryStream(imagemEmBytes, 0, imagemEmBytes.Length))
                    {
                        Image foto = Image.FromStream(ms, true);
                        fotoPokemon.Image = foto;
                    }
                }

                this.Text = NOME_DO_FORMULARIO;
                botaoAdicionar.Text = TEXTO_BOTAO_ADICIONAR;
            }
        }

        private void AdicionaOsCamposNoPokemon()
        {
            const int CAMPO_NUMERICO_VAZIO = -1;
            const int TIPO_PRINCIPAL_NAO_SELECIONADO = 0;
            const string CAMPO_VAZIO = "";
            const string TEXTO_PADRAO_COMBO_BOX = "--Selecionar--";

            if (pokemon == null) pokemon = new Pokemon();
            pokemon.Nome = txtNome.Text;
            pokemon.Apelido = txtApelido.Text;
            pokemon.Nivel = (txtNivel.Text == CAMPO_VAZIO) ? CAMPO_NUMERICO_VAZIO : Convert.ToInt32(txtNivel.Text);
            pokemon.Altura = (txtAltura.Text == CAMPO_VAZIO) ? CAMPO_NUMERICO_VAZIO : Convert.ToDecimal(txtAltura.Text, new CultureInfo("en-US"));
            pokemon.DataDeCaptura = dataPickerCaptura.Value;
            pokemon.TipoPrincipal = (comboBoxTipoPrincipal.Text == TEXTO_PADRAO_COMBO_BOX) ? pokemon.TipoPrincipal = TIPO_PRINCIPAL_NAO_SELECIONADO : Enum.Parse<TipoPokemon>(comboBoxTipoPrincipal.Text);
            pokemon.TipoSecundario = (comboBoxTipoSecundario.Text == TEXTO_PADRAO_COMBO_BOX) ? null : Enum.Parse<TipoPokemon>(comboBoxTipoSecundario.Text);
            pokemon.Shiny = checkBoxShiny.Checked;
        }

        private void ObtemMensagemDeErro(ValidationResult resultado)
        {
            if (!resultado.IsValid)
            {
                mensagemDeErro = resultado.ToString();
                throw new Exception();
            }
        }

        public void AoClicarBotaoAdicionar(object sender, EventArgs e)
        {
            try
            {
                AdicionaOsCamposNoPokemon();
                ValidationResult resultado = _Validacao.Validate(pokemon);
                ObtemMensagemDeErro(resultado);
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {

                MessageBox.Show(mensagemDeErro);
            }
        }

        private void AoClicarBotaoCancelar(object sender, EventArgs e)
        {
            const string CONFIRMACAO_DE_REMOCAO = "Tem certeza que deseja cancelar?";
            const string REMOCAO_BEM_SUCEDIDA = "Atualização cancelada.";

            var result = MessageBox.Show(CONFIRMACAO_DE_REMOCAO, REMOCAO_BEM_SUCEDIDA, MessageBoxButtons.YesNo);
            if(result == DialogResult.Yes) this.DialogResult = DialogResult.Cancel;
        }

        private void AoClicarNoBotaoBuscarImagem(object sender, EventArgs e)
        {
            const string FILTRO_DE_IMAGEM = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";
            
            OpenFileDialog arquivo = new();
            arquivo.Filter = FILTRO_DE_IMAGEM;
            if (arquivo.ShowDialog() == DialogResult.OK)
            {
                txtFoto.Text = arquivo.FileName;
                fotoPokemon.Image = Image.FromFile(txtFoto.Text);
                byte[] arquivoEmArrayDeBytes = File.ReadAllBytes(txtFoto.Text);
                string fotoEmBase64 = Convert.ToBase64String(arquivoEmArrayDeBytes);
                if (pokemon == null) pokemon = new Pokemon();
                pokemon.Foto = fotoEmBase64;
            }
        }

        private void AoApertarTeclaNoTxtNome(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void AoApertarTeclaNoTxtApelido(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void AoApertarTeclaNoTxtNivel(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void AoApertarTeclaNoTxtAltura(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
