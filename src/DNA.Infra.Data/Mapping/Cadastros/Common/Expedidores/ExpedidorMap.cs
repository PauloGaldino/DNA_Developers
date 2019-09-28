using DNA.Domain.Models.Cadastros.Common.Expedidores;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DNA.Infra.Data.Mapping.Cadastros.Common.Expedidores
{
    public class ExpedidorMap : IEntityTypeConfiguration<Expedidor>
    {
        public void Configure(EntityTypeBuilder<Expedidor> builder)
        {
            builder.Property(e => e.Id)
                .HasColumnName("Id");

            builder.Property(e => e.CompanhiaNome)
                .HasColumnType("Varchar(200)")
                .IsRequired();

            builder.Property(e => e.Telefone)
                .HasColumnType("Varchar(50)")
                .IsRequired();
        }
    }
}
