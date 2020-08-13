using EFLocado.Domain.Enuns;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFLocado.Domain.Entidades
{
    public class Filme
    {
        public int Id { get; set; }

        public string Titulo { get; set; }

        public EClassificacaoIndicativa ClassificacaoIndicativa { get; set; }

        public bool Lancamento { get; set; }

    }
}
