using CrudWinFormsBancoMemoria.Models;
using FluentValidation;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace CrudWinFormsBancoMemoria.Validacoes
{
    public class PokemonValidator : AbstractValidator<Pokemon>
    {
        public PokemonValidator() {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(p => p.Nome)
                .NotEmpty().WithMessage("NOME: Campo vazio.")
                .Length(3, 11).WithMessage("NOME: Inválido (Min: 3 caracteres / Max: 11 caracteres).")
                .Must(PadraoDeNomeCorreto).WithMessage("NOME: Inválido, deve conter apenas caracteres.");

            RuleFor(p => p.Apelido)
                .NotEmpty().WithMessage("APELIDO: Campo vazio")
                .Length(1, 20).WithMessage("APELIDO: (Min: 1 caractere / Max: 20 caracteres).");

            RuleFor(p => p.Nivel)
                .NotEqual(-1).WithMessage("NÍVEL: Campo de nivel vazio.")
                .ExclusiveBetween(0, 101).WithMessage("NÍVEL: Inválido (Min: 1 / Max: 100)")
                .Must(AceitaApenasNumerosInteiros).WithMessage("NÍVEL: Inválido, deve conter apenas números inteiros.");

            RuleFor(p => p.Altura)
                .NotEqual(-1).WithMessage("ALTURA: Campo de nivel vazio.")
                .ExclusiveBetween(0, 7).WithMessage("ALTURA: Inválido (Min: 0.01 / Max: 6.99)")
                .Must(AceitaApenasNumerosReais).WithMessage("ALTURA: Inválido, não aceita caracteres. Apenas ponto.");

            RuleFor(p => p.DataDeCaptura)
                .GreaterThanOrEqualTo(new DateTime(1996, 2, 27)).WithMessage("DATA DE CAPTURA: Data Mínima: 27/02/1996")
                .LessThanOrEqualTo(DateTime.Now).WithMessage($"DATA DE CAPTURA: Data Máxima: {DateTime.Now.ToShortDateString()}");

            RuleFor(p => p.TipoPrincipal)
                .NotEqual(Enum.Parse<TipoPokemon>("0")).WithMessage("TIPO PRINCIPAL: Selecione um tipo.");

            RuleFor(p => p.TipoSecundario)
                .Must((pokemon, tipoSecundario) => VerificaSeOsTipoSaoIguais(pokemon.TipoPrincipal, tipoSecundario)).WithMessage("TIPO SECUNDÁRIO: Não pode ser igual ao Tipo Primário.");

            RuleFor(p => p.Shiny)
                .NotNull().WithMessage("SHINY: Campo nulo");

            RuleFor(p => p.Foto)
                .Must(VerificaExtensaoDaImagem).WithMessage("FOTO: EXTENSÃO DA IMAGEM INVÁLIDA");
        }

        private bool PadraoDeNomeCorreto(string nome)
        {
            string padraoNome = @"^[a-zA-Z]*$";
            if (!Regex.IsMatch(nome, padraoNome))
            {
                return false;
            }
            return true;
        }

        private bool AceitaApenasNumerosInteiros(int numero)
        {
            string padraoNumero = @"^[0-9]*$";
            if(!Regex.IsMatch(Convert.ToString(numero), padraoNumero))
            {
                return false;
            }
            return true;
        }
        
        private bool AceitaApenasNumerosReais(decimal numero)
        {
            string padraoNumero = @"^[0-9]([.][0-9]{1,2})*$";
            if(!Regex.IsMatch(Convert.ToString(numero, CultureInfo.InvariantCulture), padraoNumero))
            {
                return false;
            }
            return true;
        }

        private bool VerificaSeOsTipoSaoIguais(TipoPokemon tipoPrincipal, TipoPokemon? tipoSecundario)
        {
            if (tipoPrincipal.Equals(tipoSecundario) && tipoPrincipal != 0)
            {
                tipoSecundario = null;
                return false;
            }
            return true;
        }

        private bool VerificaExtensaoDaImagem(string? foto)
        {
            if (foto == null) return true;

            var bmp = Encoding.ASCII.GetBytes("BM");
            var gif = Encoding.ASCII.GetBytes("GIF");
            var png = new byte[] { 137, 80, 78, 71 };
            var jpeg = new byte[] { 255, 216, 255, 224 };
            byte[] imagemEmBytes = Convert.FromBase64String(foto);

            if (!bmp.SequenceEqual(imagemEmBytes.Take(bmp.Length)) && !gif.SequenceEqual(imagemEmBytes.Take(gif.Length)) && !png.SequenceEqual(imagemEmBytes.Take(png.Length)) && !jpeg.SequenceEqual(imagemEmBytes.Take(jpeg.Length)))
            {
                return false;
            }
            return true;
        }
    }
}
