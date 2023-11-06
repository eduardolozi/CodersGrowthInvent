using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudWinFormsBancoMemoria.Validacoes
{
    public class ImagemInvalidaException : Exception
    {
        public ImagemInvalidaException() { }

        public ImagemInvalidaException(string message) : base(message) { }
    }
}
