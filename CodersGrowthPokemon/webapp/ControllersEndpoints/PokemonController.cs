using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CrudWinFormsBancoMemoria.Models;
using Infraestrutura.Repositorios;
using FluentValidation.Results;
using Dominio.Validacoes;

namespace webapp.wwwroot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private IRepositorio _repositorio;
        private PokemonValidator _validacao;

        public PokemonController(IRepositorio repositorio, PokemonValidator validacao) {
            this._repositorio = repositorio;
            this._validacao = validacao;
        }

        [HttpGet]
        public ActionResult<List<Pokemon>> ObterTodos() => _repositorio.ObterTodos();

        [HttpGet("{id}")]
        public ActionResult<Pokemon> ObterPorId(int id)
        {
            var pokemon = _repositorio.ObterPorId(id);
            return (pokemon == null) ? NotFound() : pokemon;
        }

        [HttpPost]
        public IActionResult Criar(Pokemon pokemon)
        {
            ValidationResult resultado = _validacao.Validate(pokemon);
            _repositorio.Criar(pokemon);
            return CreatedAtAction(nameof(ObterPorId), new { id = pokemon.Id}, pokemon);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Pokemon pokemon)
        {
            if (id != pokemon.Id) return BadRequest();
            if (_repositorio.ObterPorId(id) == null) return NotFound();

            _repositorio.Atualizar(pokemon);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Remover(int id)
        {
            var pokemon = _repositorio.ObterPorId(id);
            if (pokemon == null) return NotFound();

            _repositorio.Remover(pokemon);
            return NoContent();
        }

    }
}
