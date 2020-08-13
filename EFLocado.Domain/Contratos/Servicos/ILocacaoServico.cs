using EFLocado.Domain.Entidades;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFLocado.Domain.Contratos.Servicos
{
    public interface ILocacaoServico
    {
        Task<IEnumerable> ObterTodos();

        Task<IEnumerable> ObterTodosTabela();

        Task<IEnumerable> ObterFilmesMaisAlugadosAno();

        Task<IEnumerable> FilmesNuncaAlugados();

        Locacao ObterPorId(int id);

        //Task<Locacao> ObterNomes();

        void Adicionar(Locacao locacao);

        Task<bool> SalvarAlteracoes();

        void Atualizar(Locacao locacao);

        void Remover(Locacao locacao);
    }
}
