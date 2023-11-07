using CrudWinFormsBancoMemoria.Models;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Drawing.Design;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CrudWinFormsBancoMemoria.Validacoes
{
    public class ValidacaoCadastro
    {
        public static string ValidaOsCampos(Pokemon pokemon)
        {

        }

        public static string ValidarNome(TextBox txtNome, ErrorProvider erroNoCampoDeNome)
        {
            string padraoNome = @"^[a-zA-Z]{3,11}$";
            if(!Regex.IsMatch(txtNome.Text, padraoNome)) 
            {
                erroNoCampoDeNome.SetError(txtNome, "Nome inválido, evite usar caracteres especiais e números. Tamanho mínimo: 3 caracteres.");
                return $"Nome \"{txtNome.Text}\" inválido.\n";
            }
            return null;
        }

        public static string ValidarApelido(TextBox txtApelido, ErrorProvider erroNoCampoDeApelido)
        {
            string padraoNome = @"^[a-zA-Z0-9 ]{1,20}$";
            if(!Regex.IsMatch(txtApelido.Text, padraoNome))
            {
                erroNoCampoDeApelido.SetError(txtApelido, "Apelido inválido, evite usar caracteres especiais e números.");
                return $"Apelido \"{txtApelido.Text}\" inválido.\n";
            }
            return null;
        }

        public static string ValidarNivel(TextBox txtNivel, ErrorProvider erroNoCampoDeNivel)
        {
            string padrao = @"^([1-9]{1}|[1-9]{2}|[1-9]0|100)$";
            if (!Regex.IsMatch(txtNivel.Text, padrao) || txtNivel.Text == "")
            {
                erroNoCampoDeNivel.SetError(txtNivel, "Nivel inválido. Evite usar caracteres.");
                return $"Nivel {txtNivel.Text} inválido.\n";
            }
            return null;
        }

        public static string ValidarAltura(TextBox txtAltura, ErrorProvider erroNoCampoDeAltura) 
        {
            string padrao = @"^[0-9]([.][0-9]{1,3})?$";
            if (!Regex.IsMatch(txtAltura.Text, padrao))
            {
                erroNoCampoDeAltura.SetError(txtAltura, "Altura inválida (MAX: 7.000m / MIN: 0.100). Evite usar caracteres");
                return $"Altura {txtAltura.Text} inválida.\n";
            }
            decimal altura = Convert.ToDecimal(txtAltura.Text);
            if (altura < 0.1m)
            {
                erroNoCampoDeAltura.SetError(txtAltura, "Altura inválida (MAX: 7.000m / MIN: 0.100). Evite usar caracteres");
                return $"Altura {txtAltura.Text} inválida.\n";
            }
            return null;
        }

        public static string ValidarDataDeCaptura(DateTimePicker dataCaptura, ErrorProvider erroNoCampoDeData)
        {
            DateTime dataLancamento = new DateTime(1996, 2, 27);
            if(dataCaptura.Value > DateTime.Now || dataCaptura.Value < dataLancamento)
            {
                erroNoCampoDeData.SetError(dataCaptura, $"Data Mínima: 27/02/1996 e Data Máxima: {DateTime.Now.ToShortDateString()}");
                return $"Data {dataCaptura.Value.ToShortDateString()} inválida.\n";
            }
            return null;
        }

        public static string ValidarTipoPrincipal(ComboBox comboBoxTipoPrincipal,  ErrorProvider erroNoCampoDeTipoPrincipal)
        {
            if(comboBoxTipoPrincipal.Text == "--Selecionar--")
            {
                erroNoCampoDeTipoPrincipal.SetError(comboBoxTipoPrincipal, "Tipo inválido");
                return $"Tipo de Pokemon inválido.\n";
            }
            return null;
        }

        public static string ValidarTipoSecundario(TipoPokemon tipoPrimario, ComboBox comboBoxTipoSecundario, ErrorProvider erroNoCampoDeTipoSecundario)
        {
            if (comboBoxTipoSecundario.Text == "--Selecionar--") return null;
            if (tipoPrimario.Equals(Enum.Parse<TipoPokemon>(comboBoxTipoSecundario.Text)))
            {
                erroNoCampoDeTipoSecundario.SetError(comboBoxTipoSecundario, "Tipo inválido");
                return "Tipo inválido, não pode ser igual ao tipo principal.\n";
            }
            return null;
        }

        public static string ValidarShiny(CheckBox checkBoxShiny, ErrorProvider erroNoCampoDeShiny) 
        {
            if(checkBoxShiny == null)
            {
                erroNoCampoDeShiny.SetError(checkBoxShiny, "Erro: CheckBox nulo.");
                return "Erro: Checkbox nulo.\n";
            }
            return null;
        }

        public static string ValidarImagem(Button botaoImagem, ErrorProvider erroNoCampoDeImagem, byte[] bytes)
        {
            var bmp = Encoding.ASCII.GetBytes("BM");     
            var gif = Encoding.ASCII.GetBytes("GIF");    
            var png = new byte[] { 137, 80, 78, 71 };   
            var jpeg = new byte[] { 255, 216, 255, 224 };

            if (!bmp.SequenceEqual(bytes.Take(bmp.Length)) && !gif.SequenceEqual(bytes.Take(gif.Length)) && !png.SequenceEqual(bytes.Take(png.Length)) && !jpeg.SequenceEqual(bytes.Take(jpeg.Length)))
            {
                erroNoCampoDeImagem.SetError(botaoImagem, "Extensão do arquivo inválida.");
                return "Extensão do arquivo inválida.\n";
            }
            return null;
        }


    }
}
