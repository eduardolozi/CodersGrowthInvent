using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudWinFormsBancoMemoria.Validacoes
{
    public class NomeInvalidoException : Exception
    {
        public NomeInvalidoException() { }

        public NomeInvalidoException(string nome) : base($"Nome \"{nome}\" inválido.") { }
    }
}
