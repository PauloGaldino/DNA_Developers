using DNA.Domain.Models.Cadastros.Pessoas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DNA.Infra.Data.Mapping.Cadastros.Pessoas.Clientes
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(c => c.Nome)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Email)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}