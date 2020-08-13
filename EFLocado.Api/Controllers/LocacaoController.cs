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
    public class LocacaoController : ControllerBase
    {
        private readonly ILocacaoServico LocacaoServico;
        public LocacaoController(ILocacaoServico locacaoServico)
        {
            LocacaoServico = locacaoServico;
        }
        // GET: api/<LocacaoController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var locacoes = await LocacaoServico.ObterTodos();
                return Ok(locacoes);
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro: {ex }");
            }
        }

        [HttpGet("tabela")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var locacoes = await LocacaoServico.ObterTodosTabela();
                return Ok(locacoes);
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro: {ex }");
            }
        }

        [HttpGet("filmes-ano")]
        public async Task<IActionResult> GetFilmesMaisAlugadosAno()
        {
            try
            {
                var locacoes = await LocacaoServico.ObterFilmesMaisAlugadosAno();
                return Ok(locacoes);
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro: {ex }");
            }
        }

        [HttpGet("nao-alugados")]
        public async Task<IActionResult> GetNaoAlugados()
        {
            try
            {
                var locacoes = await LocacaoServico.FilmesNuncaAlugados();
                return Ok(locacoes);
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro: {ex }");
            }
        }

        // POST api/<LocacaoController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Locacao locacao)
        {
            try
            {
                LocacaoServico.Adicionar(locacao);

                if (await LocacaoServico.SalvarAlteracoes())
                {
                    return Created("api/locacao", locacao);
                }
                else
                {
                    return BadRequest("Erro ao salvar locação");
                }

            }
            catch (Exception ex)
            {

                return BadRequest($"Erro: {ex}");
            }
        }

        // PUT api/<LocacaoController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Locacao locacao)
        {
            try
            {
                var locacoes = LocacaoServico.ObterPorId(id);

                if (locacoes != null)
                {
                    LocacaoServico.Atualizar(locacao);
                    if (await LocacaoServico.SalvarAlteracoes())
                    {
                        return Ok("A locacao foi atualizada com sucesso");
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

            return BadRequest("Locacao não encontrada para o ID informado");
        }

        // DELETE api/<LocacaoController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var locacoes = LocacaoServico.ObterPorId(id);

                if (locacoes != null)
                {
                    LocacaoServico.Remover(locacoes);
                    if (await LocacaoServico.SalvarAlteracoes())
                    {
                        return Ok("A locacao foi excluída com sucesso");
                    }
                    else
                    {
                        return BadRequest("Erro ao excluir a locacao , tente novamente");
                    }
                }
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro: {ex}");
            }

            return BadRequest("Locacao não encontrado para o ID informado");
        }
    }
    }

