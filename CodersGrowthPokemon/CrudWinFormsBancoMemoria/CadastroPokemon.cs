﻿using CrudWinFormsBancoMemoria.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrudWinFormsBancoMemoria
{
    public partial class CadastroPokemon : Form
    {
        public Pokemon? novoPokemon = new Pokemon();
        public byte botaoAdicionarFoiClicado = 0;
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
            cboTipoPrincipal.Items.Add(TipoPokemon.Terra);
            cboTipoPrincipal.Items.Add(TipoPokemon.Agua);
            cboTipoPrincipal.Items.Add(TipoPokemon.Veneno);
            cboTipoPrincipal.Items.Add(TipoPokemon.Inseto);
            cboTipoPrincipal.Items.Add(TipoPokemon.Fogo);
            cboTipoPrincipal.Items.Add(TipoPokemon.Fantasma);
            cboTipoPrincipal.Items.Add(TipoPokemon.Inseto);
            cboTipoPrincipal.Items.Add(TipoPokemon.Psiquico);
            cboTipoPrincipal.Items.Add(TipoPokemon.Aco);
            cboTipoPrincipal.Items.Add(TipoPokemon.Eletrico);
            cboTipoPrincipal.Items.Add(TipoPokemon.Dragao);
            cboTipoPrincipal.Items.Add(TipoPokemon.Gelo);
            cboTipoPrincipal.Items.Add(TipoPokemon.Lutador);
            cboTipoPrincipal.Items.Add(TipoPokemon.Noturno);
            cboTipoPrincipal.Items.Add(TipoPokemon.Rocha);
            cboTipoPrincipal.Items.Add(TipoPokemon.Voador);

            cboTipoSecundario.Items.Insert(0, "--Selecionar--");
            cboTipoSecundario.SelectedIndex = 0;
            cboTipoSecundario.Items.Add(TipoPokemon.Terra);
            cboTipoSecundario.Items.Add(TipoPokemon.Agua);
            cboTipoSecundario.Items.Add(TipoPokemon.Veneno);
            cboTipoSecundario.Items.Add(TipoPokemon.Inseto);
            cboTipoSecundario.Items.Add(TipoPokemon.Fogo);
            cboTipoSecundario.Items.Add(TipoPokemon.Fantasma);
            cboTipoSecundario.Items.Add(TipoPokemon.Inseto);
            cboTipoSecundario.Items.Add(TipoPokemon.Psiquico);
            cboTipoSecundario.Items.Add(TipoPokemon.Aco);
            cboTipoSecundario.Items.Add(TipoPokemon.Eletrico);
            cboTipoSecundario.Items.Add(TipoPokemon.Dragao);
            cboTipoSecundario.Items.Add(TipoPokemon.Gelo);
            cboTipoSecundario.Items.Add(TipoPokemon.Lutador);
            cboTipoSecundario.Items.Add(TipoPokemon.Noturno);
            cboTipoSecundario.Items.Add(TipoPokemon.Rocha);
            cboTipoSecundario.Items.Add(TipoPokemon.Voador);
        }



        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        public void btnAdicionar_Click(object sender, EventArgs e)
        {
            novoPokemon.Nome = txtNome.Text;
            novoPokemon.Apelido = txtApelido.Text;
            novoPokemon.Nivel = Convert.ToInt32(txtNivel.Text);
            novoPokemon.Altura = Convert.ToDecimal(txtAltura.Text);
            novoPokemon.DataDeCaptura = dtpCaptura.Value;

            novoPokemon.TipoPrincipal = Enum.Parse<TipoPokemon>(cboTipoPrincipal.Text);
            if (cboTipoSecundario.Text == "--Selecionar--") {
                novoPokemon.TipoSecundario = null;
            } else novoPokemon.TipoSecundario = Enum.Parse<TipoPokemon>(cboTipoSecundario.Text);

            novoPokemon.Shiny = cbShiny.Checked;

            this.DialogResult = DialogResult.OK;
        }

    }
}
