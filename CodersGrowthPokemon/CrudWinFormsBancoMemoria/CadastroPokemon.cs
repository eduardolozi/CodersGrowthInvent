using CrudWinFormsBancoMemoria.Models;
using CrudWinFormsBancoMemoria.Validacoes;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrudWinFormsBancoMemoria
{
    public partial class CadastroPokemon : Form
    {
        public Pokemon? pokemon;
        private string? mensagemDeErro;

        public CadastroPokemon(Pokemon pokemonEditado = null)
        {
            if (pokemonEditado != null) pokemon = pokemonEditado;
            else pokemon = null;

            InitializeComponent();
        }

        private void CarregandoCamposDoCadastro(object sender, EventArgs e)
        {
            dataPickerCaptura.Format = DateTimePickerFormat.Custom;
            dataPickerCaptura.CustomFormat = "dd/MM/yyyy";

            comboBoxTipoPrincipal.Items.Insert(0, "--Selecionar--");
            comboBoxTipoPrincipal.SelectedIndex = 0;
            comboBoxTipoPrincipal.Items.AddRange(Enum.GetValues(typeof(TipoPokemon)).Cast<Object>().ToArray());

            comboBoxTipoSecundario.Items.Insert(0, "--Selecionar--");
            comboBoxTipoSecundario.SelectedIndex = 0;
            comboBoxTipoSecundario.Items.AddRange(Enum.GetValues(typeof(TipoPokemon)).Cast<Object>().ToArray());

            if (pokemon != null)
            { 
                txtNome.Text = pokemon.Nome;
                txtApelido.Text = pokemon.Apelido;
                txtNivel.Text = pokemon.Nivel.ToString();
                txtAltura.Text = pokemon.Altura.ToString(new CultureInfo("en-US"));
                dataPickerCaptura.Value = pokemon.DataDeCaptura;
                comboBoxTipoPrincipal.Text = pokemon.TipoPrincipal.ToString();
                if (pokemon.TipoSecundario == null) comboBoxTipoSecundario.Text = "--Selecionar--";
                else comboBoxTipoSecundario.Text = pokemon.TipoSecundario.ToString();
                checkBoxShiny.Checked = pokemon.Shiny;
                byte[] imagemEmBytes = Convert.FromBase64String(pokemon.Foto);
                using (var ms = new MemoryStream(imagemEmBytes, 0, imagemEmBytes.Length))
                {
                    Image foto = Image.FromStream(ms, true);
                    fotoPokemon.Image = foto;
                }
            }
        }

        private void AdicionaOsCamposNoPokemon()
        {
            if (pokemon == null) pokemon = new Pokemon();

            pokemon.Nome = txtNome.Text;
            pokemon.Apelido = txtApelido.Text;

            if (txtNivel.Text == "") pokemon.Nivel = -1;
            else pokemon.Nivel = Convert.ToInt32(txtNivel.Text);

            if (txtAltura.Text == "") pokemon.Altura = -1;
            else pokemon.Altura = Convert.ToDecimal(txtAltura.Text, new CultureInfo("en-US"));

            pokemon.DataDeCaptura = dataPickerCaptura.Value;

            if (comboBoxTipoPrincipal.Text == "--Selecionar--") pokemon.TipoPrincipal = 0;
            else pokemon.TipoPrincipal = Enum.Parse<TipoPokemon>(comboBoxTipoPrincipal.Text);

            if (comboBoxTipoSecundario.Text == "--Selecionar--") pokemon.TipoSecundario = null;
            else pokemon.TipoSecundario = Enum.Parse<TipoPokemon>(comboBoxTipoSecundario.Text);

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
                PokemonValidator validacao = new PokemonValidator();
                ValidationResult resultado = validacao.Validate(pokemon);
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
            this.DialogResult = DialogResult.Cancel;
        }

        private void AoClicarNoBotaoBuscarImagem(object sender, EventArgs e)
        {
            OpenFileDialog arquivo = new OpenFileDialog();
            arquivo.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";
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
