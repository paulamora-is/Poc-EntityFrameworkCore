using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Poc.EntityFrameworkCore.Console.Domains;

namespace Poc.EntityFrameworkCore.Console.Data.Configurations
{
    public class PedidoItemConfiguration : IEntityTypeConfiguration<PedidoItem>
    {
        public void Configure(EntityTypeBuilder<PedidoItem> builder)
        {
            builder.ToTable("PedidoItens");
            builder.HasKey(pi => pi.Id);
            builder.Property(pi => pi.Quantidade).HasDefaultValue(1).IsRequired();
            builder.Property(pi => pi.Valor).IsRequired();
            builder.Property(pi => pi.Desconto);
        }
    }
}
