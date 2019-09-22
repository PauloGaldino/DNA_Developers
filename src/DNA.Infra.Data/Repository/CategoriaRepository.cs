using DNA.Domain.Interfaces;
using DNA.Domain.Models;
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
        public Categoria GetByNome(string nome)
        {
           return DbSet.AsNoTracking().FirstOrDefault( c =>c.Nome == nome );
        }
        public Categoria GetByDescricao(string descricao)
        {
            return DbSet.AsNoTracking().FirstOrDefault(c => c.Descricao == descricao);
        }

       
    }
}
