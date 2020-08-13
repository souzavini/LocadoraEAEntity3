using System;
using System.Collections.Generic;
using System.Text;

namespace EFLocado.Domain.Entidades
{
    public class Cliente
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public int Cpf { get; set; }

        public DateTime DataNascimento { get; set; }

    }
}
