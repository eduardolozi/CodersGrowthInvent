using CrudWinFormsBancoMemoria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Repositorios
{
    public class Repositorio : IRepositorio
    {
        private List<Pokemon> listaDePokemons = ListaSingleton.Instance;

        public List<Pokemon> ObterTodos()
        {
            return listaDePokemons;
        }

        public Pokemon ObterPorId(int id)
        {
            return listaDePokemons.ElementAt(id);
        }

        public void Remover(Pokemon pokemon)
        {
            listaDePokemons.Remove(pokemon);
        }

        public void Criar(Pokemon pokemon)
        {
            pokemon.Id = ListaSingleton.GeraId();
            listaDePokemons.Add(pokemon);
        }

        public void Atualizar(Pokemon pokemon)
        {
            int index = listaDePokemons.FindIndex(p => p.Equals(pokemon));
            listaDePokemons[index] = pokemon;
        }
    }
}
