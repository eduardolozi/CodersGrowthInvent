using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CrudWinFormsBancoMemoria.Models;
using Infraestrutura.Repositorios;
using FluentValidation.Results;
using Dominio.Validacoes;
using Microsoft.AspNetCore.Http.HttpResults;

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
        public ActionResult<List<Pokemon>> ObterTodos()
        {
            try
            {
                var pokemons = _repositorio.ObterTodos();
                return Ok(pokemons);
                
            }catch(Exception)
            {
                return NotFound();
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
            catch (Exception)
            {
                return NotFound();
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
                _repositorio.Criar(pokemon);
                return Created(pokemon.Id.ToString(), pokemon);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
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

            } catch(Exception e) when(e.Message.Equals("Id não encontrado"))
            {
                return NotFound();
            } catch(Exception e)
            {
                return BadRequest(e.Message);
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
            } catch(Exception)
            {
                return BadRequest();
            }
        }
    }
}
