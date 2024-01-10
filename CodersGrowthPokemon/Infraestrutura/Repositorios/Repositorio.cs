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

        public List<Pokemon> ObterTodos(string? nome)
        {
            if(string.IsNullOrEmpty(nome)) return listaDePokemons;
            return (from p in listaDePokemons
                    where p.Nome.ToLower().Contains(nome.ToLower()) 
                    select p).ToList();
        }

        public Pokemon ObterPorId(int id)
        {
            var pokemon = (from p in listaDePokemons
                          where p.Id == id
                          select p).FirstOrDefault();
            return pokemon;
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
            var idDoPokemon = listaDePokemons.IndexOf((from p in listaDePokemons
                                                        where p.Id == pokemon.Id
                                                        select p).First());
            listaDePokemons[idDoPokemon] = pokemon;
        }
    }
}
