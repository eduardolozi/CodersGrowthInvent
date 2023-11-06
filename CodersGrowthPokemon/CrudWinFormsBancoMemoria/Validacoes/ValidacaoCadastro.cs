using CrudWinFormsBancoMemoria.Models;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CrudWinFormsBancoMemoria.Validacoes
{
    public class ValidacaoCadastro
    {
        public static void ValidarNome(TextBox txtNome, ErrorProvider nomeErrorProvider)
        {
            string padraoNome = @"^[a-zA-Z]{3,11}$";
            if(!Regex.IsMatch(txtNome.Text, padraoNome)) 
            {
                nomeErrorProvider.SetError(txtNome, "Nome inválido, evite usar caracteres espciais e números.");
                throw new NomeInvalidoException(txtNome.Text);
            }
        }

        public static void ValidarApelido(TextBox txtApelido, ErrorProvider apelidoErrorProvider)
        {
            string padraoNome = @"^[a-zA-Z0-9 ]{1,20}$";
            if(!Regex.IsMatch(txtApelido.Text, padraoNome))
            {
                apelidoErrorProvider.SetError(txtApelido, "Apelido inválido, evite usar caracteres especiais e números.");
                throw new ApelidoInvalidoException(txtApelido.Text);
            }
        }

        public static void ValidarNivel(TextBox txtNivel, ErrorProvider nivelErrorProvider)
        {
            string padrao = @"^([1-9]{1}|[1-9]{2}|[1-9]0|100)$";
            if (!Regex.IsMatch(txtNivel.Text, padrao))
            {
                nivelErrorProvider.SetError(txtNivel, "Nivel inválido. Evite usar caracteres.");
                throw new NivelInvalidoException(txtNivel.Text);                
            }

        }

        public static void ValidarAltura(TextBox txtAltura, ErrorProvider alturaErrorProvider) 
        {
            string padrao = @"^[0-9]([.][0-9]{1,3})?$";
            if (!Regex.IsMatch(txtAltura.Text, padrao))
            {
                alturaErrorProvider.SetError(txtAltura, "Altura inválida (MAX: 7.000m / MIN: 0.100). Evite usar caracteres");
                throw new AlturaInvalidaException(txtAltura.Text);
            }
            decimal altura = Convert.ToDecimal(txtAltura.Text);
            if (altura < 0.1m)
            {
                alturaErrorProvider.SetError(txtAltura, "Altura inválida (MAX: 7.000m / MIN: 0.100). Evite usar caracteres");
                throw new AlturaInvalidaException(txtAltura.Text);
            }
        }

        public static void ValidarDataDeCaptura(DateTimePicker dataCaptura, ErrorProvider dataErrorProvider)
        {
            DateTime dataLancamento = new DateTime(1996, 2, 27);
            if(dataCaptura.Value > DateTime.Now || dataCaptura.Value < dataLancamento)
            {
                dataErrorProvider.SetError(dataCaptura, $"Data Mínima: 27/02/1996 e Data Máxima: {DateTime.Now.ToShortDateString()}");
                throw new DataInvalidaException(dataCaptura.Value);
            }
        }

        public static void ValidarTipoPrincipal(ComboBox cboTipoPrincipal,  ErrorProvider cboTipoPrincipalErrorProvider)
        {
            if(cboTipoPrincipal.Text == "--Selecionar--")
            {
                cboTipoPrincipalErrorProvider.SetError(cboTipoPrincipal, "Tipo inválido");
                throw new TipoInvalidoException(cboTipoPrincipal.Text);
            }
        }

        public static void ValidarTipoSecundario(TipoPokemon tipoPrimario, ComboBox cboTipoSecundario, ErrorProvider cboTipoSecundarioErrorProvider)
        {
            if (cboTipoSecundario.Text == "--Selecionar--") return;
            if (tipoPrimario.Equals(Enum.Parse<TipoPokemon>(cboTipoSecundario.Text)))
            {
                cboTipoSecundarioErrorProvider.SetError(cboTipoSecundario, "Tipo inválido");
                throw new TipoInvalidoException(cboTipoSecundario.Text);
            }
        }

        public static void ValidarShiny(CheckBox cbShiny, ErrorProvider cbShinyErrorProvider) 
        {
            if(cbShiny == null)
            {
                cbShinyErrorProvider.SetError(cbShiny, "Erro: CheckBox nulo.");
                throw new("Erro: Checkbox nulo.");
            }
        }

        public static void ValidarImagem(Button botaoImagem, byte[] bytes, ErrorProvider fotoErrorProvider)
        {
            var bmp = Encoding.ASCII.GetBytes("BM");     
            var gif = Encoding.ASCII.GetBytes("GIF");    
            var png = new byte[] { 137, 80, 78, 71 };   
            var jpeg = new byte[] { 255, 216, 255, 224 };

            if (!bmp.SequenceEqual(bytes.Take(bmp.Length)) && !gif.SequenceEqual(bytes.Take(gif.Length)) && !png.SequenceEqual(bytes.Take(png.Length)) && !jpeg.SequenceEqual(bytes.Take(jpeg.Length)))
            {
                fotoErrorProvider.SetError(botaoImagem, "Extensão do arquivo inválida.");
                throw new ImagemInvalidaException("Extensão do arquivo inválida.");
            }
        }
    }
}
