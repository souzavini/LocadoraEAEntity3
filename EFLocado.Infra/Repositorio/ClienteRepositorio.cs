using EFLocado.Domain.Contratos;
using EFLocado.Domain.Entidades;
using EFLocado.Infra.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFLocado.Infra.Repositorio
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        protected readonly DataContext EFContexto;
        public ClienteRepositorio(DataContext efContexto)
        {
            EFContexto = efContexto;
        }
        public void Adicionar(Cliente cliente)
        {
            EFContexto.Add(cliente);
        }

        public void Atualizar(Cliente cliente)
        {
            EFContexto.Update(cliente);
        }

        public async Task<IEnumerable> ObterNomes()
        {
            var query = (from c in EFContexto.Clientes
                         select new
                         {
                             c.Id,
                             c.Nome
                         }).ToListAsync();

            return await query;
        }

        public Cliente ObterPorId(int id)
        {
            IQueryable<Cliente> query = EFContexto.Clientes
                .AsNoTracking()
                .OrderBy(c => c.Id);
                

            return query.FirstOrDefault(c => c.Id == id);
        }

        public async Task<IEnumerable> ObterTodos()
        {
            IQueryable<Cliente> query = EFContexto.Clientes
                .AsNoTracking()
                .OrderBy(c => c.Id);

            return await query.ToArrayAsync();
        }

        public void Remover(Cliente cliente)
        {
            EFContexto.Remove(cliente);
        }

        public async Task<bool> SalvarAlteracoes()
        {
            return (await EFContexto.SaveChangesAsync()) > 0;
        }
    }
}
