using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudWinFormsBancoMemoria.Validacoes
{
    public class DataInvalidaException : Exception
    {
        public DataInvalidaException() { }

        public DataInvalidaException(DateTime data) : base($"Data Mínima: 27/02/1996 e Data Máxima: {DateTime.Now.ToShortDateString()}") { }
    }
}
