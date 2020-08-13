using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFLocado.Domain.Contratos.Servicos;
using EFLocado.Domain.Entidades;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EFLocado.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private readonly IFilmeServico FilmeServico;
        public FilmeController(IFilmeServico filmeServico)
        {
            FilmeServico = filmeServico;
        }

        // GET: api/<FilmeController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var filmes = await FilmeServico.ObterTodos();
                return Ok(filmes);
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro: {ex }");
            }
        }

        [HttpGet("nome")]
        public async Task<IActionResult> GetNome()
        {
            try
            {
                var filmes = await FilmeServico.ObterNomes();
                return Ok(filmes);
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro: {ex }");
            }
        }

        // GET api/<FilmeController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var filmes =  FilmeServico.ObterPorId(id);

                if (filmes == null)
                {
                    return BadRequest("Cliente não encontrado para o ID informado");
                }

                return Ok(filmes);
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro: {ex }");
            }
        }

        // POST api/<FilmeController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Filme filme)
        {
            try
            {
                FilmeServico.Adicionar(filme);

                if (await FilmeServico.SalvarAlteracoes())
                {
                    return Created("api/cliente", filme);
                }
                else
                {
                    return BadRequest("Erro ao salvar filme");
                }

            }
            catch (Exception ex)
            {

                return BadRequest($"Erro: {ex}");
            }
        }

        // PUT api/<FilmeController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Filme filme)
        {
            try
            {
                var filmes = FilmeServico.ObterPorId(id);

                if (filmes != null)
                {
                    FilmeServico.Atualizar(filme);
                    if (await FilmeServico.SalvarAlteracoes())
                    {
                        return Ok("O Filme foi atualizado com sucesso");
                    }
                    else
                    {
                        return BadRequest("Erro ao atualizar , tente novamente");
                    }
                }
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro: {ex}");
            }

            return BadRequest("Filme não encontrado para o ID informado");
        }

        // DELETE api/<FilmeController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var filmes = FilmeServico.ObterPorId(id);

                if (filmes != null)
                {
                    FilmeServico.Remover(filmes);
                    if (await FilmeServico.SalvarAlteracoes())
                    {
                        return Ok("O Filme foi excluído com sucesso");
                    }
                    else
                    {
                        return BadRequest("Erro ao excluir o filme , tente novamente");
                    }
                }
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro: {ex}");
            }

            return BadRequest("Filme não encontrado para o ID informado");
        }
    }
}
