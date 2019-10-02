using DNA.Domain.Interfaces.Cadastros.Pessoas.Empregados;
using DNA.Domain.Models.Cadastros.Pessoas;
using DNA.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DNA.Infra.Data.Repository.Cadastros.Pessoas.Empregados
{
    public class EmpregadoRepository : Repository<Empregado>, IEmpregadoRepository
    {
        public EmpregadoRepository(DNAContext context)
            : base(context)
        {

        }

        public Empregado GetByNome(string nome)
        {
            return DbSet.AsNoTracking().FirstOrDefault(c => c.Nome == nome);
        }
    }
}
