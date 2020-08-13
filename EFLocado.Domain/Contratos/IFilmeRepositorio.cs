using EFLocado.Domain.Entidades;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFLocado.Domain.Contratos
{
    public interface IFilmeRepositorio
    {
        Task<IEnumerable> ObterTodos();

        Filme ObterPorId(int id);

        Task<IEnumerable> ObterNomes();

        void Adicionar(Filme filme);

        Task<bool> SalvarAlteracoes();

        void Atualizar(Filme filme);

        void Remover(Filme filme);

        IEnumerable<Filme> FilmesNaoAlugados();
    }
}
