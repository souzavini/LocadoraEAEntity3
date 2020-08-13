using EFLocado.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFLocado.Infra.Config
{
    public class LocacaoConfiguracao : IEntityTypeConfiguration<Locacao>
    {
        public void Configure(EntityTypeBuilder<Locacao> builder)
        {
            builder.HasKey(l => l.Id);

            builder
                .HasMany(l => l.LocacaoItens);
                

            builder
                .Property(l => l.ClienteId)
                .IsRequired();
        }
    }
}
