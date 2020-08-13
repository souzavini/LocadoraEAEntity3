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
    public class ClienteController : ControllerBase
    {
        private readonly IClienteServico ClienteServico;
        public ClienteController(IClienteServico clienteServico)
        {
            ClienteServico = clienteServico;
        }

        // GET: api/<ClienteController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var clientes = await ClienteServico.ObterTodos();
                return Ok(clientes);
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
                var clientes = await ClienteServico.ObterNomes();
                return Ok(clientes);
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro: {ex }");
            }
        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var cliente = ClienteServico.ObterPorId(id);

                if(cliente == null)
                {
                    return BadRequest("Cliente não encontrado para o ID informado");
                }

                return Ok(cliente);
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro: {ex }");
            }
        }

        // POST api/<ClienteController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Cliente cliente)
        {
            try
            {
                ClienteServico.Adicionar(cliente);

                if(await ClienteServico.SalvarAlteracoes())
                {
                    return Created("api/cliente", cliente);
                }
                else
                {
                    return BadRequest("Erro ao salvar cliente");
                }

            }
            catch (Exception ex)
            {

                return BadRequest($"Erro: {ex}");
            }
        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Cliente cliente)
        {
            try
            {
                var clientes =  ClienteServico.ObterPorId(id);

                if(clientes != null)
                {
                    ClienteServico.Atualizar(cliente);
                    if(await ClienteServico.SalvarAlteracoes())
                    {
                        return Ok("O Cliente foi atualizado com sucesso");
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

            return BadRequest("Cliente não encontrado para o ID informado");
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var clientes = ClienteServico.ObterPorId(id);

                if (clientes != null)
                {
                    ClienteServico.Remover(clientes);
                    if (await ClienteServico.SalvarAlteracoes())
                    {
                        return Ok("O Cliente foi excluído com sucesso");
                    }
                    else
                    {
                        return BadRequest("Erro ao excluir o cliente , tente novamente");
                    }
                }
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro: {ex}");
            }

            return BadRequest("Cliente não encontrado para o ID informado");
        }
    }
}
