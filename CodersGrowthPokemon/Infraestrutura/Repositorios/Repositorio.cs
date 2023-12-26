﻿using CrudWinFormsBancoMemoria.Models;
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

        public int Criar(Pokemon pokemon)
        {
            pokemon.Id = ListaSingleton.GeraId();
            listaDePokemons.Add(pokemon);
            return pokemon.Id;
        }

        public void Atualizar(Pokemon pokemon)
        {
            int index = listaDePokemons.FindIndex(p => p.Equals(pokemon));
            listaDePokemons[index] = pokemon;
        }
    }
}
