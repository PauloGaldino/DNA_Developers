using DNA.Domain.Interfaces.Cadastros.Common.Expedidores;
using DNA.Domain.Models.Cadastros.Common.Expedidores;
using DNA.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DNA.Infra.Data.Repository.Cadastros.Common.Expedidores
{
    public class ExpedidorRepository : Repository<Expedidor>, IExpedidorRepository
    {
        public ExpedidorRepository(DNAContext context) :base(context) {}
        public Expedidor GetByNomeCompanhia(string companhiaNome)
        {
            return DbSet.AsNoTracking().FirstOrDefault(e => e.CompanhiaNome == companhiaNome);
        }
    }
}
