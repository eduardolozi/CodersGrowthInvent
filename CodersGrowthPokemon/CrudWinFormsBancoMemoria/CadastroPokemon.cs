using CrudWinFormsBancoMemoria.Models;
using CrudWinFormsBancoMemoria.Validacoes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
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
        public CadastroPokemon()
        {
            InitializeComponent();
        }

        private void CadastroPokemon_Load(object sender, EventArgs e)
        {
            dtpCaptura.Format = DateTimePickerFormat.Custom;
            dtpCaptura.CustomFormat = "dd/MM/yyyy";

            cboTipoPrincipal.Items.Insert(0, "--Selecionar--");
            cboTipoPrincipal.SelectedIndex = 0;
            foreach (var item in Enum.GetValues(typeof(TipoPokemon)))
            {
                cboTipoPrincipal.Items.Add(item);
            }

            cboTipoSecundario.Items.Insert(0, "--Selecionar--");
            cboTipoSecundario.SelectedIndex = 0;
            foreach (var item in Enum.GetValues(typeof(TipoPokemon)))
            {
                cboTipoSecundario.Items.Add(item);
            }
        }

        private void aoClicarBotaoCancelar(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        public void aoClicarBotaoAdicionar(object sender, EventArgs e)
        {
            try
            {
                ValidacaoCadastro.ValidarNome(txtNome, nomeErrorProvider);
                novoPokemon.Nome = txtNome.Text;
                nomeErrorProvider.SetError(txtNome, "");

                ValidacaoCadastro.ValidarApelido(txtApelido, apelidoErrorProvider);
                novoPokemon.Apelido = txtApelido.Text;
                apelidoErrorProvider.SetError(txtApelido, "");

                ValidacaoCadastro.ValidarNivel(txtNivel, nivelErrorProvider);
                novoPokemon.Nivel = Convert.ToInt32(txtNivel.Text);
                nivelErrorProvider.SetError(txtNivel, "");

                ValidacaoCadastro.ValidarAltura(txtAltura, alturaErrorProvider);
                novoPokemon.Altura = Convert.ToDecimal(txtAltura.Text, new CultureInfo("en-US"));
                alturaErrorProvider.SetError(txtAltura, "");

                ValidacaoCadastro.ValidarDataDeCaptura(dtpCaptura, dataErrorProvider);
                novoPokemon.DataDeCaptura = dtpCaptura.Value;
                dataErrorProvider.SetError(dtpCaptura, "");

                ValidacaoCadastro.ValidarTipoPrincipal(cboTipoPrincipal, cboTipoPrincipalErrorProvider);
                novoPokemon.TipoPrincipal = Enum.Parse<TipoPokemon>(cboTipoPrincipal.Text);
                cboTipoPrincipalErrorProvider.SetError(cboTipoPrincipal, "");

                ValidacaoCadastro.ValidarTipoSecundario(novoPokemon.TipoPrincipal, cboTipoSecundario, cboTipoSecundarioErrorProvider);
                if (cboTipoSecundario.Text == "--Selecionar--")
                {
                    novoPokemon.TipoSecundario = null;
                }
                else novoPokemon.TipoSecundario = Enum.Parse<TipoPokemon>(cboTipoSecundario.Text);
                cboTipoSecundarioErrorProvider.SetError(cboTipoSecundario, "");

                ValidacaoCadastro.ValidarShiny(cbShiny, cbShinyErrorProvider);
                novoPokemon.Shiny = cbShiny.Checked;
                cbShinyErrorProvider.SetError(cbShiny, "");

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex) when (ex is NomeInvalidoException || ex is ApelidoInvalidoException || ex is NivelInvalidoException || ex is AlturaInvalidaException || ex is DataInvalidaException || ex is TipoInvalidoException || ex is ShinyInvalidoException)
            {
                MessageBox.Show(ex.Message);
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

        private void AoClicarNoBotaoBuscarImagem(object sender, EventArgs e)
        {
            OpenFileDialog arquivo = new OpenFileDialog();
            arquivo.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";
            if (arquivo.ShowDialog() == DialogResult.OK)
            {
                txtFoto.Text = arquivo.FileName;
                fotoPokemon.Image = Image.FromFile(txtFoto.Text);
                byte[] bytes =  File.ReadAllBytes(txtFoto.Text);
                string fotoEmBase64 = Convert.ToBase64String(bytes);
                novoPokemon.Foto = fotoEmBase64;
            }
        }
    }

}
