using System;
using System.Collections.Generic;
using System.Text;

namespace EFLocado.Domain.Entidades
{
    public class LocacaoItens
    {
        public LocacaoItens(Filme filme)
        {
            Filme = filme;
            DataLocacao = DateTime.Now;
            if (filme.Lancamento == true)
            {
                DataDevolucao = DateTime.Now.AddDays(2);
            }

            DataDevolucao = DateTime.Now.AddDays(3);
        }

        public LocacaoItens()
        {

        }

        public int Id { get; set; }
        public Filme Filme { get; set; }
        public int FilmeId { get; set; }

        public DateTime DataLocacao { get; set; }

        public DateTime DataDevolucao { get; set; }
    }
}
