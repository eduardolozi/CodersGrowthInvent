using CrudWinFormsBancoMemoria.Models;
using CrudWinFormsBancoMemoria.Validacoes;
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
        public Pokemon? novoPokemon = new Pokemon();
        private string mensagemDeErro;
        public CadastroPokemon()
        {
            InitializeComponent();
        }

        private void CadastroPokemon_Load(object sender, EventArgs e)
        {
            dataPickerCaptura.Format = DateTimePickerFormat.Custom;
            dataPickerCaptura.CustomFormat = "dd/MM/yyyy";

            comboBoxTipoPrincipal.Items.Insert(0, "--Selecionar--");
            comboBoxTipoPrincipal.SelectedIndex = 0;
            foreach (var item in Enum.GetValues(typeof(TipoPokemon)))
            {
                comboBoxTipoPrincipal.Items.Add(item);
            }

            comboBoxTipoSecundario.Items.Insert(0, "--Selecionar--");
            comboBoxTipoSecundario.SelectedIndex = 0;
            foreach (var item in Enum.GetValues(typeof(TipoPokemon)))
            {
                comboBoxTipoSecundario.Items.Add(item);
            }
        }

        private void AdicionaOsCamposNoPokemon()
        {
            novoPokemon.Nome = txtNome.Text;
            novoPokemon.Apelido = txtApelido.Text;
            novoPokemon.Nivel = Convert.ToInt32(txtNivel.Text);
            novoPokemon.Altura = Convert.ToDecimal(txtAltura.Text, new CultureInfo("en-US"));
            novoPokemon.DataDeCaptura = dataPickerCaptura.Value;
            novoPokemon.TipoPrincipal = Enum.Parse<TipoPokemon>(comboBoxTipoPrincipal.Text);
            if (comboBoxTipoSecundario.Text == "--Selecionar--")
            {
                novoPokemon.TipoSecundario = null;
            }
            else novoPokemon.TipoSecundario = Enum.Parse<TipoPokemon>(comboBoxTipoSecundario.Text);
            novoPokemon.Shiny = checkBoxShiny.Checked;
        }

        private void ValidaOsCampos()
        {
            ValidacaoCadastro.ValidaOsCampos(novoPokemon, erroNoCampo);
        }

        public void AoClicarBotaoAdicionar(object sender, EventArgs e)
        {
            try
            {
                AdicionaOsCamposNoPokemon();
                ValidaOsCampos();

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AoClicarBotaoCancelar(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
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

        private void AoClicarNoBotaoBuscarImagem(object sender, EventArgs e)
        {
            OpenFileDialog arquivo = new OpenFileDialog();
            arquivo.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";
            if (arquivo.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    txtFoto.Text = arquivo.FileName;
                    fotoPokemon.Image = Image.FromFile(txtFoto.Text);
                    byte[] arquivoEmArrayDeBytes = File.ReadAllBytes(txtFoto.Text);
                    string fotoEmBase64 = Convert.ToBase64String(arquivoEmArrayDeBytes);
                    ValidacaoCadastro.DefineValidacao(botaoImagem, erroNoCampo, arquivoEmBytes: arquivoEmArrayDeBytes);
                    novoPokemon.Foto = fotoEmBase64;
                    erroNoCampo.SetError(botaoImagem, "");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(mensagemDeErro);
                }
            }
        }
    }

}
