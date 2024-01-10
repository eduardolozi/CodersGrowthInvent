using CrudWinFormsBancoMemoria.Models;
using Dominio.Enums;
using Dominio.Validacoes;
using FluentValidation;
using FluentValidation.Results;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Dominio.Validacoes{
    public class PokemonValidator : AbstractValidator<Pokemon>
    {
        public static readonly DateTime DataMinima = new (1996, 2, 27);
        public PokemonValidator() {
            RuleLevelCascadeMode = CascadeMode.Stop;

            const string NOME = "NOME";
            const string APELIDO = "APELIDO";
            const string NIVEL = "NIVEL";
            const string ALTURA = "ALTURA";
            const int TAMANHO_MINIMO_NOME = 3;
            const int TAMANHO_MAXIMO_NOME = 11;
            const int TAMANHO_MINIMO_APELIDO = 1;
            const int TAMANHO_MAXIMO_APELIDO = 20;
            const int NIVEL_INVALIDO = -1;
            const int NUMERO_MINIMO = 0;
            const int NIVEL_MAXIMO = 101;
            const int ALTURA_INVALIDA = -1;
            const int ALTURA_MAXIMA = 7;
            const string TIPO_INVALIDO = "0";
            

            RuleFor(p => p.Nome)
                .NotEmpty().WithMessage(MensagensDeValidacao.GerarErroCampoVazio(NOME))
                .Length(TAMANHO_MINIMO_NOME, TAMANHO_MAXIMO_NOME).WithMessage(MensagensDeValidacao.TAMANHO_NOME_INVALIDO)
                .Must(PadraoDeNomeCorreto).WithMessage(MensagensDeValidacao.FORMATO_NOME_INVALIDO);

            RuleFor(p => p.Apelido)
                .NotEmpty().WithMessage(MensagensDeValidacao.GerarErroCampoVazio(APELIDO))
                .Length(TAMANHO_MINIMO_APELIDO, TAMANHO_MAXIMO_APELIDO).WithMessage(MensagensDeValidacao.TAMANHO_APELIDO_INVALIDO);

            RuleFor(p => p.Nivel)
                .NotEqual(NIVEL_INVALIDO).WithMessage(MensagensDeValidacao.GerarErroCampoVazio(NIVEL))
                .ExclusiveBetween(NUMERO_MINIMO, NIVEL_MAXIMO).WithMessage(MensagensDeValidacao.VALOR_NIVEL_INVALIDO)
                .Must(AceitaApenasNumerosInteiros).WithMessage(MensagensDeValidacao.FORMATO_NIVEL_INVALIDO);

            RuleFor(p => p.Altura)
                .NotEqual(ALTURA_INVALIDA).WithMessage(MensagensDeValidacao.GerarErroCampoVazio(ALTURA))
                .ExclusiveBetween(NUMERO_MINIMO, ALTURA_MAXIMA).WithMessage(MensagensDeValidacao.VALOR_ALTURA_INVALIDO)
                .Must(AceitaApenasNumerosReais).WithMessage(MensagensDeValidacao.FORMATO_ALTURA_INVALIDO);

            RuleFor(p => p.DataDeCaptura)
                .GreaterThanOrEqualTo(DataMinima).WithMessage(MensagensDeValidacao.VALOR_DATA_MENOR)
                .LessThanOrEqualTo(DateTime.Now.AddDays(1)).WithMessage(MensagensDeValidacao.ValorDataMaior);

            RuleFor(p => p.TipoPrincipal)
                .NotEqual(Enum.Parse<TipoPokemonEnum>(TIPO_INVALIDO)).WithMessage(MensagensDeValidacao.CAMPO_TIPO_PRINCIPAL_VAZIO);

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
            return Regex.IsMatch(nome, PADRAO_NOME);
        }

        private bool AceitaApenasNumerosInteiros(int numero)
        {
            const string PADRAO_NUMERO_INTEIRO = @"^[0-9]*$";
            return Regex.IsMatch(Convert.ToString(numero), PADRAO_NUMERO_INTEIRO);
        }
        
        private bool AceitaApenasNumerosReais(decimal numero)
        {
            const string PADRAO_NUMERO_REAL = @"^[0-9]([.][0-9]{1,2})*$";
            return Regex.IsMatch(Convert.ToString(numero, CultureInfo.InvariantCulture), PADRAO_NUMERO_REAL);
        }

        private bool VerificaSeOsTipoSaoIguais(TipoPokemonEnum tipoPrincipal, TipoPokemonEnum? tipoSecundario)
        {
            const int TIPO_INVALIDO = 0;
            return (!tipoPrincipal.Equals(tipoSecundario) && tipoPrincipal != TIPO_INVALIDO);
        }

        private bool VerificaExtensaoDaImagem(string? foto)
        {
            if (foto == null) return true;

            const int SUBSTRING_HTTP = 23;
            const int SUBSTRING_HTTPS = 24;
            var bmp = Encoding.ASCII.GetBytes("BM");
            var gif = Encoding.ASCII.GetBytes("GIF");
            var png = new byte[] { 137, 80, 78, 71 };
            var jpeg = new byte[] { 255, 216, 255, 224 };

            if (foto.Contains("http")) foto = foto.Substring(SUBSTRING_HTTP);
            if (foto.Contains("https")) foto = foto.Substring(SUBSTRING_HTTPS);

            byte[] imagemEmBytes = Convert.FromBase64String(foto);

            if (!bmp.SequenceEqual(imagemEmBytes.Take(bmp.Length)) && !gif.SequenceEqual(imagemEmBytes.Take(gif.Length)) && !png.SequenceEqual(imagemEmBytes.Take(png.Length)) && !jpeg.SequenceEqual(imagemEmBytes.Take(jpeg.Length)))
            {
                return false;
            }
            return true;
        }
    }
}
