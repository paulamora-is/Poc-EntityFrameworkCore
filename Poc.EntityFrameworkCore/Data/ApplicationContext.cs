using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Poc.EntityFrameworkCore.Console.Domains;
using System;

namespace Poc.EntityFrameworkCore.Console.Data
{
    public class ApplicationContext: DbContext
    {
        private static readonly ILoggerFactory _logger = LoggerFactory.Create(p => p.AddConsole());
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<PedidoItem> PedidoItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Poc.EntityFrameworkCore.Console;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False",
                optionsBuilder => optionsBuilder.EnableRetryOnFailure(maxRetryCount: 2, maxRetryDelay: TimeSpan.FromSeconds(5), errorNumbersToAdd: null)) //tornando a aplicação mais resiliente

            .UseLoggerFactory(_logger)
            .EnableSensitiveDataLogging(); //ver o valor dos parâmetros no console
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
        }
    }
}
