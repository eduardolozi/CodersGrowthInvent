using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CrudWinFormsBancoMemoria.Models;
using Infraestrutura.Repositorios;
using FluentValidation.Results;
using Dominio.Validacoes;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Text.Json;

namespace webapp.wwwroot.Controllers
{
    [Route("/pokemons")]
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
        public ActionResult<List<Pokemon>> ObterTodos([FromQuery] string? nome)
        {
            try
            {
                List<Pokemon> pokemons;
                if (string.IsNullOrEmpty(nome))  _repositorio.ObterTodos(null);
                pokemons = _repositorio.ObterTodos(nome);

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
                ValidationResult resultado = _validacao.Validate(pokemon);
                if (!resultado.IsValid)
                {
                    var mensagemDeErro = resultado.ToString();
                    throw new Exception(mensagemDeErro);
                }
                var idPokemon = _repositorio.Criar(pokemon);
                pokemon.Id = idPokemon;
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
            try
            {
                if (_repositorio.ObterPorId(id) == null) throw new Exception("Id não encontrado");
                pokemon.Id = id;
            
                ValidationResult resultado = _validacao.Validate(pokemon);
                if (!resultado.IsValid)
                {
                    var mensagemDeErro = resultado.ToString();
                    throw new Exception(mensagemDeErro);
                }

                _repositorio.Atualizar(pokemon);
                return Ok(pokemon);

            } catch(Exception ex) when(ex.Message.Equals("Id não encontrado"))
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
