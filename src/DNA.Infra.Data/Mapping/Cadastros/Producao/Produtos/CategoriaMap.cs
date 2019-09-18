using DNA.Domain.Models.Cadastros.Producao;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DNA.Infra.Data.Mapping.Cadastros.Producao.Produtos
{
    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(c => c.Descricao)
                .HasColumnType("Varchar(200)")
                .IsRequired();
        }
    }
}
