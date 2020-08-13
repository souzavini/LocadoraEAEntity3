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
    public class LocacaoServico : ILocacaoServico
    {
        private readonly ILocacaoRepositorio LocacaoRepositorio;
        private readonly IFilmeRepositorio FilmeRepositorio;
        private readonly IClienteRepositorio ClienteRepositorio;
        public LocacaoServico(ILocacaoRepositorio locacaoRepositorio, IFilmeRepositorio filmeRepositorio, IClienteRepositorio clienteRepositorio)
        {
            LocacaoRepositorio = locacaoRepositorio;
            FilmeRepositorio = filmeRepositorio;
            ClienteRepositorio = clienteRepositorio;
        }
        public void Adicionar(Locacao locacao)
        {
            var clienteBanco = ClienteRepositorio.ObterPorId(locacao.ClienteId);
            var loca = new Locacao(clienteBanco,clienteBanco.Id);

            foreach(var item in locacao.LocacaoItens)
            {
                var filmes = FilmeRepositorio.ObterPorId(item.Filme.Id);
                loca.adicionarItem(new LocacaoItens(filmes));
            }
            
            LocacaoRepositorio.Adicionar(locacao);
        }

        public void Atualizar(Locacao locacao)
        {
            LocacaoRepositorio.Atualizar(locacao);
        }

        public async Task<IEnumerable> FilmesNuncaAlugados()
        {
            return await LocacaoRepositorio.FilmesNuncaAlugados();
        }

        public async Task<IEnumerable> ObterFilmesMaisAlugadosAno()
        {
            return await LocacaoRepositorio.ObterFilmesMaisAlugadosAno();
        }

        public Locacao ObterPorId(int id)
        {
           return LocacaoRepositorio.ObterPorId(id);
        }

        public async Task<IEnumerable> ObterTodos()
        {
            return await LocacaoRepositorio.ObterTodos();
        }

        public async Task<IEnumerable> ObterTodosTabela()
        {
           return await LocacaoRepositorio.ObterTodosTabela();
        }

        public void Remover(Locacao locacao)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SalvarAlteracoes()
        {
            return await LocacaoRepositorio.SalvarAlteracoes();
        }
    }
}
