using EFLocado.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFLocado.Infra.Config
{
    public class ClienteConfiguracao : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(c => c.Id);

            builder
                .Property(c => c.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)")
                .IsRequired();

            builder
                .Property(c => c.Cpf)
                .HasColumnType("varchar(11)")
                .IsRequired();

            builder
                .Property(c => c.DataNascimento)
                .IsRequired();
        }
    }
}
