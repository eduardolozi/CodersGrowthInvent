using CrudWinFormsBancoMemoria.Models;
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

        public static ListaSingleton<Pokemon> RedefineIdAposRemocao(ListaSingleton<Pokemon> listaDePokemons, int idRemovido)
        {
            for (int i = idRemovido - 1; i < listaDePokemons.Count; i++)
            {
                listaDePokemons[i].Id = i + 1;
            }
            return listaDePokemons;
        }
        
    }



}
