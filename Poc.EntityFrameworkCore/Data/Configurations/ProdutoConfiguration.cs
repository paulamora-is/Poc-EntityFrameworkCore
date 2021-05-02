using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Poc.EntityFrameworkCore.Console.Domains;

namespace Poc.EntityFrameworkCore.Console.Data.Configurations
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produtos");
            builder.HasKey(pe => pe.Id);
            builder.Property(pe => pe.CodigoBarras).HasColumnType("VARCHAR(14)").IsRequired();
            builder.Property(pe => pe.Descricao).HasColumnType("VARCHAR(60)");
            builder.Property(pe => pe.Valor).IsRequired();
            builder.Property(pe => pe.TipoProduto).HasConversion<string>();
        }
    }
}
