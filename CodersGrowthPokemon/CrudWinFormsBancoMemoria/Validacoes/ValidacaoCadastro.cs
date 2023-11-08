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
        private static Control RetornaOCampo(Control.ControlCollection campos, string nomeDoCampo)
        {
            return campos.Find(nomeDoCampo, true).FirstOrDefault();
        }

        private static void DesativaOAlertaDeErro(Control campo, string mensagemDeErro, ErrorProvider erroNoCampo)
        {
            if (mensagemDeErro == null) erroNoCampo.SetError(campo, "");
        }

        public static string ValidaOsCampos(Pokemon pokemon, ErrorProvider erroNoCampo, Control.ControlCollection campos)
        {
            string mensagemDeErroGeral = null;
            string mensagemDeErroDoCampo = null;
            
            var campoDoCadastro = (TextBox)RetornaOCampo(campos, "txtNome");
            mensagemDeErroDoCampo = ValidarNome(campoDoCadastro, erroNoCampo, pokemon);
            mensagemDeErroGeral += mensagemDeErroDoCampo;
            DesativaOAlertaDeErro(campoDoCadastro, mensagemDeErroDoCampo, erroNoCampo);

            campoDoCadastro = (TextBox)RetornaOCampo(campos, "txtApelido");
            mensagemDeErroDoCampo = ValidarApelido(campoDoCadastro, erroNoCampo, pokemon);
            mensagemDeErroGeral += mensagemDeErroDoCampo;
            DesativaOAlertaDeErro(campoDoCadastro, mensagemDeErroDoCampo, erroNoCampo);

            campoDoCadastro = (TextBox)RetornaOCampo(campos, "txtNivel");
            mensagemDeErroDoCampo = ValidarNivel(campoDoCadastro, erroNoCampo, pokemon);
            mensagemDeErroGeral += mensagemDeErroDoCampo;
            DesativaOAlertaDeErro(campoDoCadastro, mensagemDeErroDoCampo, erroNoCampo);

            campoDoCadastro = (TextBox)RetornaOCampo(campos, "txtAltura");
            mensagemDeErroDoCampo = ValidarAltura(campoDoCadastro, erroNoCampo, pokemon);
            mensagemDeErroGeral += mensagemDeErroDoCampo;
            DesativaOAlertaDeErro(campoDoCadastro, mensagemDeErroDoCampo, erroNoCampo);

            var campoDeData = (DateTimePicker)RetornaOCampo(campos, "dataPickerCaptura");
            mensagemDeErroDoCampo = ValidarDataDeCaptura(campoDeData, erroNoCampo, pokemon);
            mensagemDeErroGeral += mensagemDeErroDoCampo;
            DesativaOAlertaDeErro(campoDeData, mensagemDeErroDoCampo, erroNoCampo);

            var campoDeTipo = (ComboBox)RetornaOCampo(campos, "comboBoxTipoPrincipal");
            mensagemDeErroDoCampo = ValidarTipoPrincipal(campoDeTipo, erroNoCampo, pokemon);
            mensagemDeErroGeral += mensagemDeErroDoCampo;
            DesativaOAlertaDeErro(campoDeTipo, mensagemDeErroDoCampo, erroNoCampo);

            campoDeTipo = (ComboBox)RetornaOCampo(campos, "comboBoxTipoSecundario");
            mensagemDeErroDoCampo = ValidarTipoSecundario(campoDeTipo, erroNoCampo, pokemon);
            mensagemDeErroGeral += mensagemDeErroDoCampo;
            DesativaOAlertaDeErro(campoDeTipo, mensagemDeErroDoCampo, erroNoCampo);

            var campoDeShiny = (CheckBox)RetornaOCampo(campos, "checkBoxShiny");
            mensagemDeErroDoCampo = ValidarShiny(campoDeShiny, erroNoCampo, pokemon);
            mensagemDeErroGeral += mensagemDeErroDoCampo;
            DesativaOAlertaDeErro(campoDeShiny, mensagemDeErroDoCampo, erroNoCampo);

            return mensagemDeErroGeral;
        }

        public static string ValidarNome(TextBox txtNome, ErrorProvider erroNoCampoDeNome, Pokemon pokemon)
        {
            string padraoNome = @"^[a-zA-Z]{3,11}$";
            if(pokemon.Nome == "0")
            {
                erroNoCampoDeNome.SetError(txtNome, "Campo vazio.");
                return $"Campo de nome vazio.\n";
            }
            else if(!Regex.IsMatch(pokemon.Nome, padraoNome)) 
            {
                erroNoCampoDeNome.SetError(txtNome, "Nome inválido, evite usar caracteres especiais e números. Min: 3 caracteres.");
                return $"Nome \"{txtNome.Text}\" inválido.\n";
            }

            return null;
        }

        public static string ValidarApelido(TextBox txtApelido, ErrorProvider erroNoCampoDeApelido, Pokemon pokemon)
        {
            string padraoNome = @"^[a-zA-Z0-9 ]{1,20}$";
            if(pokemon.Apelido == "0")
            {
                erroNoCampoDeApelido.SetError(txtApelido, "Campo vazio.");
                return $"Campo de apelido vazio.\n";
            }
            else if(!Regex.IsMatch(pokemon.Apelido, padraoNome))
            {
                erroNoCampoDeApelido.SetError(txtApelido, "Apelido inválido, evite usar caracteres especiais e números.");
                return $"Apelido \"{txtApelido.Text}\" inválido.\n";
            }

            return null;
        }

        public static string ValidarNivel(TextBox txtNivel, ErrorProvider erroNoCampoDeNivel, Pokemon pokemon)
        {
            string padrao = @"^([1-9]{1}|[1-9]{2}|[1-9]0|100)$";
            if (pokemon.Nivel == -1)
            {
                erroNoCampoDeNivel.SetError(txtNivel, "Campo vazio.");
                return $"Campo de nível vazio.\n";
            }
            else if (!Regex.IsMatch(txtNivel.Text, padrao))
            {
                erroNoCampoDeNivel.SetError(txtNivel, "Nivel inválido. Min: 1 / Max: 100");
                return $"Nivel {txtNivel.Text} inválido.\n";
            }

            return null;
        }

        public static string ValidarAltura(TextBox txtAltura, ErrorProvider erroNoCampoDeAltura, Pokemon pokemon) 
        {
            string padrao = @"^[0-9]([.][0-9]{1,3})?$";
            if (pokemon.Altura == -1)
            {
                erroNoCampoDeAltura.SetError(txtAltura, "Campo vazio.");
                return $"Campo de altura vazio.\n";
            }
            else if (!Regex.IsMatch(txtAltura.Text, padrao))
            {
                erroNoCampoDeAltura.SetError(txtAltura, "Altura inválida (Min: 0.100m / Max: 7.000m).");
                return $"Altura {txtAltura.Text} inválida.\n";
            }

            decimal altura = Convert.ToDecimal(txtAltura.Text);
            if (altura < 0.1m)
            {
                erroNoCampoDeAltura.SetError(txtAltura, "Altura inválida (Min: 0.100m / Max: 7.000m).");
                return $"Altura {txtAltura.Text} inválida.\n";
            }
            
            return null;
        }

        public static string ValidarDataDeCaptura(DateTimePicker dataCaptura, ErrorProvider erroNoCampoDeData, Pokemon pokemon)
        {
            DateTime dataLancamento = new DateTime(1996, 2, 27);
            if(pokemon.DataDeCaptura > DateTime.Now || pokemon.DataDeCaptura < dataLancamento)
            {
                erroNoCampoDeData.SetError(dataCaptura, $"Data Min: 27/02/1996 e Data Max: {DateTime.Now.ToShortDateString()}");
                return $"Data {dataCaptura.Value.ToShortDateString()} inválida.\n";
            }
            return null;
        }

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
