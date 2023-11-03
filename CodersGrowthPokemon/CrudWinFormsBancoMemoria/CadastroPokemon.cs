using CrudWinFormsBancoMemoria.Models;
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
            novoPokemon.Nome = txtNome.Text;
            novoPokemon.Apelido = txtApelido.Text;
            novoPokemon.Nivel = Convert.ToInt32(txtNivel.Text);
            novoPokemon.Altura = Convert.ToDecimal(txtAltura.Text);
            novoPokemon.DataDeCaptura = dtpCaptura.Value;

            novoPokemon.TipoPrincipal = Enum.Parse<TipoPokemon>(cboTipoPrincipal.Text);
            if (cboTipoSecundario.Text == "--Selecionar--")
            {
                novoPokemon.TipoSecundario = null;
            }
            else novoPokemon.TipoSecundario = Enum.Parse<TipoPokemon>(cboTipoSecundario.Text);

            novoPokemon.Shiny = cbShiny.Checked;

            this.DialogResult = DialogResult.OK;
        }

    }
}
