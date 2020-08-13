using EFLocado.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFLocado.Infra.Config
{
    public class LocacaoItensConfiguracao : IEntityTypeConfiguration<LocacaoItens>
    {
        public void Configure(EntityTypeBuilder<LocacaoItens> builder)
        {
            builder.HasKey(lo => lo.Id);

            builder
                .Property(lo => lo.DataLocacao)
                .IsRequired();

            builder
                .Property(lo => lo.DataDevolucao)
                .IsRequired();
        }
    }
}
