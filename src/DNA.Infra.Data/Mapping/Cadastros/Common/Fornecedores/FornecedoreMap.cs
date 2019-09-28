using DNA.Domain.Models.Cadastros.Common.Fornecedores;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DNA.Infra.Data.Mapping.Cadastros.Common.Fornecedores
{
    public class FornecedoreMap : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.Property(f => f.Id)
               .HasColumnName("Id");

            builder.Property(f => f.NomeCompanhia)
                .HasColumnType("Varchar(200)")
                .IsRequired();

            builder.Property(f => f.NomeContato)
               .HasColumnType("Varchar(200)")
               .IsRequired();

            builder.Property(f => f.TituloContato)
              .HasColumnType("Varchar(200)")
              .IsRequired();

            builder.Property(f => f.Telefone)
              .HasColumnType("Varchar(50)")
              .IsRequired();

            builder.Property(f => f.EnderecoEmail)
              .HasColumnType("Varchar(200)")
              .IsRequired();

            builder.Property(f => f.Cidade)
              .HasColumnType("Varchar(200)")
              .IsRequired();

            builder.Property(f => f.Estado)
             .HasColumnType("Varchar(150)")
             .IsRequired();

            builder.Property(f => f.Pais)
            .HasColumnType("Varchar(150)")
            .IsRequired();
        }
    }
}

