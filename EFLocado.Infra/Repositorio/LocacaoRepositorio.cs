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
    public class LocacaoRepositorio : ILocacaoRepositorio
    {
        protected readonly DataContext EFContexto;
        public LocacaoRepositorio(DataContext efContexto)
        {
            EFContexto = efContexto;
        }

        public void Adicionar(Locacao locacao)
        {

            EFContexto.Add(locacao);
            
        }

        public void Atualizar(Locacao locacao)
        {
            EFContexto.Update(locacao);
        }

        public async Task<IEnumerable> FilmesNuncaAlugados()
        {
            var query = (from l in EFContexto.LocacoesItens
                         join f in EFContexto.Filmes on l.FilmeId equals f.Id
                         where l.DataLocacao == null
                         select new
                         {
                             
                             NomeFilme = f.Titulo,
                         }).ToListAsync();

            return await query;
        }

        public async Task<IEnumerable> ObterFilmesMaisAlugadosAno()
        {

            var query = (from l in EFContexto.LocacoesItens
                         join f in EFContexto.Filmes on l.FilmeId equals f.Id
                         where l.DataLocacao.Year == 2019
                         select new
                         {
                             NomeFilme = f.Titulo.Count(),
                         }).ToListAsync();

            return await query;
        }

        public Locacao ObterPorId(int id)
        {
            IQueryable<Locacao> query = EFContexto.Locacoes
                .AsNoTracking()
                .OrderBy(f => f.Id);


            return query.FirstOrDefault(f => f.Id == id);
        }

        public async Task<IEnumerable> ObterTodos()
        {
            IQueryable<Locacao> query = EFContexto.Locacoes
                .Include(l=>l.LocacaoItens)
                .AsNoTracking()
                .OrderBy(l=>l.Id);

            return await query.ToArrayAsync();
        }

        public async Task<IEnumerable> ObterTodosTabela()
        {

            var query = (from l in EFContexto.LocacoesItens
                        join f in EFContexto.Filmes on l.FilmeId equals f.Id
                        select new
                        {
                            IdLocacao = l.Id,
                            NomeFilme = f.Titulo,
                            DataAluguel = l.DataLocacao,
                            DataDevolucao = l.DataDevolucao
                        }).ToListAsync();

            return await query;
        }

        public void Remover(Locacao locacao)
        {
            EFContexto.Remove(locacao);
        }

        public async Task<bool> SalvarAlteracoes()
        {
            return (await EFContexto.SaveChangesAsync()) > 0;
        }
    }
}
