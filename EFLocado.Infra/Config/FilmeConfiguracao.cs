using EFLocado.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFLocado.Infra.Config
{
    public class FilmeConfiguracao : IEntityTypeConfiguration<Filme>
    {
        public void Configure(EntityTypeBuilder<Filme> builder)
        {
            builder.HasKey(f => f.Id);

            builder
                .Property(f => f.Titulo)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder
                .Property(f => f.ClassificacaoIndicativa)
                .HasColumnType("int")
                .IsRequired();

            builder
                .Property(f => f.Lancamento)
                .HasColumnType("tinyint")
                .IsRequired();
        }
    }
}
