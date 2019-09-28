using DNA.Domain.Models.Cadastros.Pessoas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DNA.Infra.Data.Mapping.Cadastros.Pessoas.Empregados
{
    public class EmpregadoMap : IEntityTypeConfiguration<Empregado>
    {
        public void Configure(EntityTypeBuilder<Empregado> builder)
        {
            builder.Property(c => c.Id)
               .HasColumnName("Id");

            builder.Property(c => c.Nome)
              .HasColumnType("varchar(150)")
              .HasMaxLength(150)
              .IsRequired();

            builder.Property(c => c.Sobrenome)
             .HasColumnType("varchar(150)")
             .HasMaxLength(150)
             .IsRequired();

            builder.Property(c => c.Cargo)
                .HasColumnType("varchar(150)")
                .HasMaxLength(150)
                .IsRequired();

        }
    }
}
