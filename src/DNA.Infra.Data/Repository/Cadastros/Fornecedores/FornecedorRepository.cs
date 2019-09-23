using DNA.Domain.Interfaces.Cadastros.Common.Fornecedores;
using DNA.Domain.Models.Cadastros.Common.Fornecedores;
using DNA.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DNA.Infra.Data.Repository.Cadastros.Fornecedores
{
   public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(DNAContext context) : base(context){ }

   
        public Fornecedor GetByNomeCompanhia(string nomeCompania)
        {
            return DbSet.AsNoTracking().FirstOrDefault(f =>f.NomeCompanhia== nomeCompania);
        }
    }
}
