using CrudWinFormsBancoMemoria.Models;
using Dominio.Enums;
using Dominio.Validacoes;
using FluentValidation;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Dominio.Validacoes{
    public class PokemonValidator : AbstractValidator<Pokemon>
    {
        public PokemonValidator() {
            RuleLevelCascadeMode = CascadeMode.Stop;

            const string NOME = "NOME";
            const string APELIDO = "APELIDO";
            const string NIVEL = "NIVEL";
            const string ALTURA = "ALTURA";

            RuleFor(p => p.Nome)
                .NotEmpty().WithMessage(MensagensDeValidacao.GerarErroCampoVazio(NOME))
                .Length(3, 11).WithMessage(MensagensDeValidacao.TAMANHO_NOME_INVALIDO)
                .Must(PadraoDeNomeCorreto).WithMessage(MensagensDeValidacao.FORMATO_NOME_INVALIDO);

            RuleFor(p => p.Apelido)
                .NotEmpty().WithMessage(MensagensDeValidacao.GerarErroCampoVazio(APELIDO))
                .Length(1, 20).WithMessage(MensagensDeValidacao.TAMANHO_APELIDO_INVALIDO);

            RuleFor(p => p.Nivel)
                .NotEqual(-1).WithMessage(MensagensDeValidacao.GerarErroCampoVazio(NIVEL))
                .ExclusiveBetween(0, 101).WithMessage(MensagensDeValidacao.VALOR_NIVEL_INVALIDO)
                .Must(AceitaApenasNumerosInteiros).WithMessage(MensagensDeValidacao.FORMATO_NIVEL_INVALIDO);

            RuleFor(p => p.Altura)
                .NotEqual(-1).WithMessage(MensagensDeValidacao.GerarErroCampoVazio(ALTURA))
                .ExclusiveBetween(0, 7).WithMessage(MensagensDeValidacao.VALOR_ALTURA_INVALIDO)
                .Must(AceitaApenasNumerosReais).WithMessage(MensagensDeValidacao.FORMATO_ALTURA_INVALIDO);

            RuleFor(p => p.DataDeCaptura)
                .GreaterThanOrEqualTo(new DateTime(1996, 2, 27)).WithMessage(MensagensDeValidacao.VALOR_DATA_MENOR)
                .LessThanOrEqualTo(DateTime.Now.AddDays(1)).WithMessage(MensagensDeValidacao.ValorDataMaior);

            RuleFor(p => p.TipoPrincipal)
                .NotEqual(Enum.Parse<TipoPokemon>("0")).WithMessage(MensagensDeValidacao.CAMPO_TIPO_PRINCIPAL_VAZIO);

            RuleFor(p => p.TipoSecundario)
                .Must((pokemon, tipoSecundario) => VerificaSeOsTipoSaoIguais(pokemon.TipoPrincipal, tipoSecundario)).WithMessage(MensagensDeValidacao.CAMPO_TIPO_SECUNDARIO_INVALIDO);

            RuleFor(p => p.Shiny)
                .NotNull().WithMessage(MensagensDeValidacao.CAMPO_SHINY_NULO);

            RuleFor(p => p.Foto)
                .Must(VerificaExtensaoDaImagem).WithMessage(MensagensDeValidacao.EXTENSAO_FOTO_INVALIDA);
        }

        private bool PadraoDeNomeCorreto(string nome)
        {
            const string PADRAO_NOME = @"^[a-zA-Z]*$";
            if (!Regex.IsMatch(nome, PADRAO_NOME)) return false;
            else return true;
        }

        private bool AceitaApenasNumerosInteiros(int numero)
        {
            const string PADRAO_NUMERO_INTEIRO = @"^[0-9]*$";
            if (!Regex.IsMatch(Convert.ToString(numero), PADRAO_NUMERO_INTEIRO)) return false;
            else return true;
        }
        
        private bool AceitaApenasNumerosReais(decimal numero)
        {
            const string PADRAO_NUMERO_REAL = @"^[0-9]([.][0-9]{1,2})*$";
            if (!Regex.IsMatch(Convert.ToString(numero, CultureInfo.InvariantCulture), PADRAO_NUMERO_REAL)) return true;
            else return true;
        }

        private bool VerificaSeOsTipoSaoIguais(TipoPokemon tipoPrincipal, TipoPokemon? tipoSecundario)
        {
            if (tipoPrincipal.Equals(tipoSecundario) && tipoPrincipal != 0) return false;
            else return true;
        }

        private bool VerificaExtensaoDaImagem(string? foto)
        {
            if (foto == null) return true;

            var bmp = Encoding.ASCII.GetBytes("BM");
            var gif = Encoding.ASCII.GetBytes("GIF");
            var png = new byte[] { 137, 80, 78, 71 };
            var jpeg = new byte[] { 255, 216, 255, 224 };

            if (foto.Contains("http")) foto = foto.Substring(23);
            if (foto.Contains("https")) foto = foto.Substring(24);

            byte[] imagemEmBytes = Convert.FromBase64String(foto);

            if (!bmp.SequenceEqual(imagemEmBytes.Take(bmp.Length)) && !gif.SequenceEqual(imagemEmBytes.Take(gif.Length)) && !png.SequenceEqual(imagemEmBytes.Take(png.Length)) && !jpeg.SequenceEqual(imagemEmBytes.Take(jpeg.Length)))
            {
                return false;
            }
            else return true;
        }
    }
}
