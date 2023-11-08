using CrudWinFormsBancoMemoria.Models;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        

        public static string ValidarTipoPrincipal(ComboBox comboBoxTipoPrincipal,  ErrorProvider erroNoCampoDeTipoPrincipal, Pokemon pokemon)
        {
            if(pokemon.TipoPrincipal == 0)
            {
                erroNoCampoDeTipoPrincipal.SetError(comboBoxTipoPrincipal, "Tipo inválido");
                return $"Tipo Principal de Pokemon inválido.\n";
            }
            return null;
        }

        public static string ValidarTipoSecundario(ComboBox comboBoxTipoSecundario, ErrorProvider erroNoCampoDeTipoSecundario, Pokemon pokemon)
        {
            if (pokemon.TipoPrincipal.Equals(pokemon.TipoSecundario) && pokemon.TipoPrincipal != 0)
            {
                erroNoCampoDeTipoSecundario.SetError(comboBoxTipoSecundario, "Tipo inválido");
                pokemon.TipoSecundario = null;
                return "Tipo Secundário inválido, não pode ser igual ao tipo principal.\n";
            }
            return null;
        }

        public static string ValidarShiny(CheckBox checkBoxShiny, ErrorProvider erroNoCampoDeShiny, Pokemon pokemon) 
        {
            if(pokemon.Shiny == null)
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
