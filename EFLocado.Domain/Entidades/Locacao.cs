using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFLocado.Domain.Entidades
{
    public class Locacao
    {
        public Locacao(Cliente cliente,int clienteId)
        {
            Cliente = cliente;
            ClienteId = clienteId;
            LocacaoItens = new List<LocacaoItens>();
        }

        public Locacao()
        {

        }

        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public int ClienteId { get; set; }

        public virtual List<LocacaoItens> LocacaoItens { get; set; }

        public void adicionarItem(LocacaoItens itens)
        {
           LocacaoItens.Add(itens);
        }
    }
}
