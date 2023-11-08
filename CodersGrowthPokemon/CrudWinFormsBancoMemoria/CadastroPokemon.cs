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
        private string? mensagemDeErro;
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
            if (txtNome.Text == "") novoPokemon.Nome = "0";
            else novoPokemon.Nome = txtNome.Text;

            if (txtApelido.Text == "") novoPokemon.Apelido = "0";
            else novoPokemon.Apelido = txtApelido.Text;

            if (txtNivel.Text == "") novoPokemon.Nivel = -1;
            else novoPokemon.Nivel = Convert.ToInt32(txtNivel.Text);

            if(txtAltura.Text == "") novoPokemon.Altura = -1;
            else novoPokemon.Altura = Convert.ToDecimal(txtAltura.Text, new CultureInfo("en-US"));
            
            novoPokemon.DataDeCaptura = dataPickerCaptura.Value;

            if (comboBoxTipoPrincipal.Text == "--Selecionar--") novoPokemon.TipoPrincipal = 0;
            else novoPokemon.TipoPrincipal = Enum.Parse<TipoPokemon>(comboBoxTipoPrincipal.Text);

            if (comboBoxTipoSecundario.Text == "--Selecionar--") novoPokemon.TipoSecundario = 0;
            else novoPokemon.TipoSecundario = Enum.Parse<TipoPokemon>(comboBoxTipoSecundario.Text);

            novoPokemon.Shiny = checkBoxShiny.Checked;
        }

        private string ValidacaoDoCadastro()
        {
            return ValidacaoCadastro.ValidaOsCampos(novoPokemon, erroNoCampo, this.Controls);
        }

        public void AoClicarBotaoAdicionar(object sender, EventArgs e)
        {
            try
            {
                AdicionaOsCamposNoPokemon();
                mensagemDeErro = ValidacaoDoCadastro();
                if (mensagemDeErro != "") throw new Exception();

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
                string mensagemDaExcecao;
                try
                {
                    txtFoto.Text = arquivo.FileName;
                    fotoPokemon.Image = Image.FromFile(txtFoto.Text);
                    byte[] arquivoEmArrayDeBytes = File.ReadAllBytes(txtFoto.Text);
                    string fotoEmBase64 = Convert.ToBase64String(arquivoEmArrayDeBytes);
                    mensagemDaExcecao = ValidacaoCadastro.ValidarImagem(botaoImagem, erroNoCampo, arquivoEmArrayDeBytes);
                    novoPokemon.Foto = fotoEmBase64;
                    erroNoCampo.SetError(botaoImagem, "");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }

}
