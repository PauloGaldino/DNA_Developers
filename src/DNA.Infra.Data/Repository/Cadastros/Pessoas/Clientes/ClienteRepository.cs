using DNA.Domain.Interfaces.Cadastros.Pessoas.Clientes;
using DNA.Domain.Models.Cadastros.Pessoas;
using DNA.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DNA.Infra.Data.Repository.Cadastros.Pessoas.Clientes
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(DNAContext context)
            : base(context)
        {

        }

        public Cliente GetByEmail(string email)
        {
            return DbSet.AsNoTracking().FirstOrDefault(c => c.Email == email);
        }
    }
}
