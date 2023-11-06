using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudWinFormsBancoMemoria.Validacoes
{
    public class ShinyInvalidoException : Exception
    {
        public ShinyInvalidoException() { }

        public ShinyInvalidoException(string message) : base(message) { }
    }
}
