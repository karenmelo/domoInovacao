using Conta.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Conta.Infra.Data.EntitiesMapping;

public class TransacaoMapping : IEntityTypeConfiguration<Transacao>
{
    public void Configure(EntityTypeBuilder<Transacao> builder)
    {
        builder.ToTable("Transacao");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.DataTransacao).HasColumnType("date");
        builder.Property(x => x.TipoTransacao).IsRequired().HasColumnType("varchar(30)");
        builder.Property(x => x.Local).IsRequired().HasColumnType("varchar(30)");
        builder.Property(x => x.Valor).IsRequired().HasColumnType("decimal(10, 2)");
    }
}