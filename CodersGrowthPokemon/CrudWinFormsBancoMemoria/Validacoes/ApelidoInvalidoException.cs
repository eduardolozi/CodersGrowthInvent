using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudWinFormsBancoMemoria.Validacoes
{
    public class ApelidoInvalidoException : Exception
    {
        public ApelidoInvalidoException() { }

        public ApelidoInvalidoException(string apelido) : base($"Apelido \"{apelido}\" inválido") { }
    }
}
