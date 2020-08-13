using EFLocado.Domain.Entidades;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFLocado.Domain.Contratos
{
    public interface IClienteRepositorio
    {
        Task<IEnumerable> ObterTodos();

        Cliente ObterPorId(int id);

        Task<IEnumerable> ObterNomes();

        void Adicionar(Cliente cliente);

        Task<bool> SalvarAlteracoes();

        void Atualizar(Cliente cliente);

        void Remover(Cliente cliente);

    }
}
