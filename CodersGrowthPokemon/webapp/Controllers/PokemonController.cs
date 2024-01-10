using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CrudWinFormsBancoMemoria.Models;
using Infraestrutura.Repositorios;
using FluentValidation.Results;
using Dominio.Validacoes;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Text.Json;
using FluentValidation;

namespace webapp.wwwroot.Controllers
{
    [Route("/pokemons")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly IRepositorio _repositorio;
        private readonly PokemonValidator _validacao;

        public PokemonController(IRepositorio repositorio, PokemonValidator validacao) {
            _repositorio = repositorio;
            _validacao = validacao;
        }

        [HttpGet]
        public ActionResult<List<Pokemon>> ObterTodos([FromQuery] string? nome)
        {
            try
            {
                List<Pokemon> pokemons = (string.IsNullOrEmpty(nome)) ? _repositorio.ObterTodos(null) : _repositorio.ObterTodos(nome);

                return Ok(pokemons);
            }catch(Exception ex)
            {
                var erroJson = JsonSerializer.Serialize(ex.Message);
                return NotFound(erroJson);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Pokemon> ObterPorId([FromRoute]int id)
        {
            try
            {
                var pokemon = _repositorio.ObterPorId(id);
                return Ok(pokemon);
            }
            catch (Exception ex)
            {
                var erroJson = JsonSerializer.Serialize(ex.Message);
                return BadRequest(erroJson);
            }
        }

        [HttpPost]
        public IActionResult Criar([FromBody]Pokemon pokemon)
        {
            try
            {
                ExtensaoFluentValidation.ValidateAndThrowArgumentsException(_validacao, pokemon);
                _repositorio.Criar(pokemon);
                string uri = $"/pokemons/{pokemon.Id}";
                return Created(uri, pokemon);
            }
            catch (Exception ex)
            {
                var erroJson = JsonSerializer.Serialize(ex.Message);
                return BadRequest(erroJson);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar([FromRoute]int id,[FromBody] Pokemon pokemon)
        {
            const string MENSAGEM_DE_ERRO_ATUALIZAR = "Pokemon não encontrado pelo id";

            try
            {
                if (_repositorio.ObterPorId(id) == null) throw new Exception(MENSAGEM_DE_ERRO_ATUALIZAR);
                pokemon.Id = id;
            
                ExtensaoFluentValidation.ValidateAndThrowArgumentsException(_validacao, pokemon);

                _repositorio.Atualizar(pokemon);
                return Ok(pokemon);

            } catch(Exception ex) when(ex.Message.Equals(MENSAGEM_DE_ERRO_ATUALIZAR))
            {
                var erroJson = JsonSerializer.Serialize(ex.Message);
                return NotFound(erroJson);
            } catch(Exception ex)
            {
                var erroJson = JsonSerializer.Serialize(ex.Message);
                return BadRequest(erroJson);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Remover([FromRoute] int id)
        {
            try
            {
                var pokemon = _repositorio.ObterPorId(id);
                _repositorio.Remover(pokemon);
                return Ok(pokemon);
            } catch(Exception ex)
            {
                var erroJson = JsonSerializer.Serialize(ex.Message);
                return BadRequest(erroJson);
            }
        }
    }
}
