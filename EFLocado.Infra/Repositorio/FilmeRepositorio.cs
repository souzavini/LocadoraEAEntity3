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
    public class FilmeRepositorio : IFilmeRepositorio
    {
        protected readonly DataContext EFContexto;
        public FilmeRepositorio(DataContext efContexto)
        {
            EFContexto = efContexto;
        }
        public void Adicionar(Filme filme)
        {
            EFContexto.Add(filme);
        }

        public void Atualizar(Filme filme)
        {
            EFContexto.Update(filme);
        }

        public IEnumerable<Filme> FilmesNaoAlugados()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable> ObterNomes()
        {
            var query = (from f in EFContexto.Filmes
                         select new
                         {
                             f.Id,
                             f.Titulo
                         }).ToListAsync();

            return await query;
        }

        public Filme ObterPorId(int id)
        {
            IQueryable<Filme> query = EFContexto.Filmes
                .AsNoTracking()
                .OrderBy(f => f.Id);


            return query.FirstOrDefault(f=>f.Id == id);
        }

        public async Task<IEnumerable> ObterTodos()
        {
            IQueryable<Filme> query = EFContexto.Filmes
               .AsNoTracking()
               .OrderBy(f => f.Id);

            return await query.ToArrayAsync();
        }

        public void Remover(Filme filme)
        {
            EFContexto.Remove(filme);
        }

        public async Task<bool> SalvarAlteracoes()
        {
            return (await EFContexto.SaveChangesAsync()) > 0;
        }
    }
}
