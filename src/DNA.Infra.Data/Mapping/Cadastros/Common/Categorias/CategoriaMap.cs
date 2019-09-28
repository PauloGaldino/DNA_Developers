using DNA.Domain.Models.Cadastros.Common.Categorias;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DNA.Infra.Data.Mapping.Cadastros.Common.Categorias
{
    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(c => c.Nome)
                .HasColumnType("Varchar(150)")
                .IsRequired();

            builder.Property(c => c.Descricao)
                .HasColumnType("Varchar(200)")
                .IsRequired();
        }
    }
}
