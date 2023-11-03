using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudWinFormsBancoMemoria.Validacoes
{
    public class NivelInvalidoException : Exception
    {
        public NivelInvalidoException() { }

        public NivelInvalidoException(string nivel) : base($"Nivel {nivel} inválido") { }
    }
}
