using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudWinFormsBancoMemoria.Validacoes
{
    public class AlturaInvalidaException : Exception
    {
        public AlturaInvalidaException() { }

        public AlturaInvalidaException(string altura) : base($"Altura {altura} inválida") { }
    }
}
