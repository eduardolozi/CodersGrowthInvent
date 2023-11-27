using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Validacoes
{
    public class MensagensDeValidacao
    {
        public const string TAMANHO_NOME_INVALIDO = "NOME: Inválido (Min: 3 caracteres / Max: 11 caracteres).";
        public const string FORMATO_NOME_INVALIDO = "NOME: Inválido, deve conter apenas caracteres.";

        public const string TAMANHO_APELIDO_INVALIDO = "APELIDO: (Min: 1 caractere / Max: 20 caracteres).";

        public const string VALOR_NIVEL_INVALIDO = "NÍVEL: Inválido (Min: 1 / Max: 100).";
        public const string FORMATO_NIVEL_INVALIDO = "NÍVEL: Inválido, deve conter apenas números inteiros.";

        public const string VALOR_ALTURA_INVALIDO = "ALTURA: Inválido (Min: 0.01 / Max: 6.99).";
        public const string FORMATO_ALTURA_INVALIDO = "ALTURA: Inválido, não aceita caracteres. Apenas ponto.";

        public const string VALOR_DATA_MENOR = "DATA DE CAPTURA: Data Mínima: 27/02/1996";
        public static readonly string ValorDataMaior = $"DATA DE CAPTURA: Data Máxima: {DateTime.Now.ToShortDateString()}.";

        public const string CAMPO_TIPO_PRINCIPAL_VAZIO = "TIPO PRINCIPAL: Selecione um tipo.";

        public const string CAMPO_TIPO_SECUNDARIO_INVALIDO = "TIPO SECUNDÁRIO: Não pode ser igual ao Tipo Primário.";

        public const string CAMPO_SHINY_NULO = "SHINY: Campo nulo";

        public const string EXTENSAO_FOTO_INVALIDA = "FOTO: EXTENSÃO DA IMAGEM INVÁLIDA";

        public static string GerarErroCampoVazio(string campo)
        {
            return $"{campo}: Campo vazio.";
        }

    }
}
