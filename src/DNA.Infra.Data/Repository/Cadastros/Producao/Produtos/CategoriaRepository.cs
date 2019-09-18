using DNA.Domain.Interfaces.Cadastros.Producao.Produtos;
using DNA.Domain.Models.Cadastros.Producao;
using DNA.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DNA.Infra.Data.Repository.Cadastros.Producao.Produtos
{
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(DNAContext context):base(context)
        {

        }
        public Categoria GetByDescricao(string descricao)
        {
            return DbSet.AsNoTracking().FirstOrDefault(c => c.Descricao == descricao);
        }
    }
}
