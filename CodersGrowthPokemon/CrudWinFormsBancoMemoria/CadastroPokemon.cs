﻿using CrudWinFormsBancoMemoria.Models;
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
        public Pokemon? novoPokemon = new Pokemon();
        private string? mensagemDeErro;
        private int indiceDoPokemon = -1;

        public CadastroPokemon(int indicePokemon = -1, Pokemon pokemonEditado = null)
        {
            if(indicePokemon != -1 && pokemonEditado != null)
            {
                indiceDoPokemon = indicePokemon;
                novoPokemon = pokemonEditado;
            }
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

            if (indiceDoPokemon != -1)
            {
                txtNome.Text = novoPokemon.Nome;
                txtApelido.Text = novoPokemon.Apelido;
                txtNivel.Text = novoPokemon.Nivel.ToString();
                txtAltura.Text = novoPokemon.Altura.ToString();
                dataPickerCaptura.Value = novoPokemon.DataDeCaptura;
                comboBoxTipoPrincipal.Text = novoPokemon.TipoPrincipal.ToString();
                if (novoPokemon.TipoSecundario == null) comboBoxTipoSecundario.Text = "--Selecionar--";
                else comboBoxTipoSecundario.Text = novoPokemon.TipoSecundario.ToString();
                checkBoxShiny.Checked = novoPokemon.Shiny;
            }
            
        }

        private void AdicionaOsCamposNoPokemon()
        {
            novoPokemon.Nome = txtNome.Text;
            novoPokemon.Apelido = txtApelido.Text;
            
            if (txtNivel.Text == "") novoPokemon.Nivel = -1;
            else novoPokemon.Nivel = Convert.ToInt32(txtNivel.Text);

            if (txtAltura.Text == "") novoPokemon.Altura = -1;
            else novoPokemon.Altura = Convert.ToDecimal(txtAltura.Text, new CultureInfo("en-US"));

            novoPokemon.DataDeCaptura = dataPickerCaptura.Value;

            if (comboBoxTipoPrincipal.Text == "--Selecionar--") novoPokemon.TipoPrincipal = 0;
            else novoPokemon.TipoPrincipal = Enum.Parse<TipoPokemon>(comboBoxTipoPrincipal.Text);

            if (comboBoxTipoSecundario.Text == "--Selecionar--") novoPokemon.TipoSecundario = null;
            else novoPokemon.TipoSecundario = Enum.Parse<TipoPokemon>(comboBoxTipoSecundario.Text); 

            novoPokemon.Shiny = checkBoxShiny.Checked;
        }

        private void ObtemMensagemDeErro(ValidationResult resultado)
        {
            if(!resultado.IsValid)
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
                ValidationResult resultado = validacao.Validate(novoPokemon);
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
                novoPokemon.Foto = fotoEmBase64;
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
