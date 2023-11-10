using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudWinFormsBancoMemoria
{
    public class ListaSingleton<T> : List<T>
    {
        private static ListaSingleton<T> instance = null;

        private ListaSingleton() { }

        public static ListaSingleton<T> Instance
        {
            get
            {
                if (instance == null)
                    lock (typeof(ListaSingleton<T>))
                        if (instance == null) instance = new ListaSingleton<T>();

                return instance;
            }
        }

        public static int GeraId()
        {
            return ListaSingleton<T>.Instance.Count + 1;
        }
        
    }



}
