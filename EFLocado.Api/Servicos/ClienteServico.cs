using EFLocado.Domain.Contratos;
using EFLocado.Domain.Contratos.Servicos;
using EFLocado.Domain.Entidades;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFLocado.Api.Servicos
{
    public class ClienteServico : IClienteServico
    {
        private readonly IClienteRepositorio ClienteRepositorio;

        public ClienteServico(IClienteRepositorio clienteRepositorio)
        {
            ClienteRepositorio = clienteRepositorio;
        }
        public void Adicionar(Cliente cliente)
        {
            ClienteRepositorio.Adicionar(cliente);
        }

        public void Atualizar(Cliente cliente)
        {
            ClienteRepositorio.Atualizar(cliente);
        }

        public async Task<IEnumerable> ObterNomes()
        {
           return await ClienteRepositorio.ObterNomes();
        }

        public Cliente ObterPorId(int id)
        {
            return ClienteRepositorio.ObterPorId(id);
        }

        public async Task<IEnumerable> ObterTodos()
        {
            return await ClienteRepositorio.ObterTodos();
        }

        public void Remover(Cliente cliente)
        {
            ClienteRepositorio.Remover(cliente);
        }

        public async Task<bool> SalvarAlteracoes()
        {
            return await ClienteRepositorio.SalvarAlteracoes();
        }
    }
}
