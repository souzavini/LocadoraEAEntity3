using EFLocado.Domain.Entidades;
using EFLocado.Infra.Config;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFLocado.Infra.Contexto
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Filme> Filmes { get; set; }

        public DbSet<Locacao> Locacoes { get; set; }

        public DbSet<LocacaoItens> LocacoesItens  { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteConfiguracao());
            modelBuilder.ApplyConfiguration(new FilmeConfiguracao());
            modelBuilder.ApplyConfiguration(new LocacaoConfiguracao());
            modelBuilder.ApplyConfiguration(new LocacaoItensConfiguracao());
        }

    }
}
