using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudWinFormsBancoMemoria.Validacoes
{
    public class TipoInvalidoException : Exception
    {
        public TipoInvalidoException() { }

        public TipoInvalidoException(string tipo) : base("Tipo inválido.") { }
    }
}
