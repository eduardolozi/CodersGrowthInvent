﻿using CrudWinFormsBancoMemoria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Repositorios
{
    public class ListaSingleton
    {
        private static List<Pokemon> instance = null;
        private static int contadorDeId = 0;
        const int INCREMENTO_DE_ID = 1;

        public static List<Pokemon> Instance
        {
            get
            {
                if (instance == null)
                    lock (typeof(ListaSingleton))
                        if (instance == null) instance = new List<Pokemon>();

                return instance;
            }
        }

        public static int GeraId()
        {
            contadorDeId+=INCREMENTO_DE_ID;
            return contadorDeId;
        }
    }
}
