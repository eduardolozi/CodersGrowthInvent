using CrudWinFormsBancoMemoria.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Validacoes
{
    public static class ExtensaoFluentValidation
    {
        public static void ValidateAndThrowArgumentsException(this PokemonValidator validator, Pokemon instancia)
        {
            var resultado = validator.Validate(instancia);

            if(!resultado.IsValid)
            {
                var exception = new ValidationException(resultado.Errors);
                throw new ArgumentException(exception.Message, exception);
            }
        }
    }
}
