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
        public CadastroPokemon()
        {
            InitializeComponent();
        }

        private void CadastroPokemon_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "ddd dd MMM YYYY";

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

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
