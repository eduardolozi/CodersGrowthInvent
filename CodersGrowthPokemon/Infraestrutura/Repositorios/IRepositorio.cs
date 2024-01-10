using CrudWinFormsBancoMemoria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Repositorios
{
    public interface IRepositorio
    {
        public List<Pokemon> ObterTodos(string? nome);
        public Pokemon ObterPorId(int id);
        public void Remover(Pokemon pokemon);
        public void Criar(Pokemon novoPokemon);
        public void Atualizar(Pokemon pokemon);
    }
}
