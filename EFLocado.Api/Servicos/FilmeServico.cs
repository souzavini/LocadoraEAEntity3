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
    public class FilmeServico : IFilmeServico
    {
        private readonly IFilmeRepositorio FilmeRepositorio;

        public FilmeServico(IFilmeRepositorio filmeRepositorio)
        {
            FilmeRepositorio = filmeRepositorio;
        }
        public void Adicionar(Filme filme)
        {
            FilmeRepositorio.Adicionar(filme);
        }

        public void Atualizar(Filme filme)
        {
            FilmeRepositorio.Atualizar(filme);
        }

        public IEnumerable<Filme> FilmesNaoAlugados()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable> ObterNomes()
        {
            return await FilmeRepositorio.ObterNomes();
        }

        public Filme ObterPorId(int id)
        {
            return FilmeRepositorio.ObterPorId(id);
        }

        public async Task<IEnumerable> ObterTodos()
        {
            return await FilmeRepositorio.ObterTodos();
        }

        public void Remover(Filme filme)
        {
            FilmeRepositorio.Remover(filme);
        }

        public async Task<bool> SalvarAlteracoes()
        {
            return await FilmeRepositorio.SalvarAlteracoes();
        }
    }
}
