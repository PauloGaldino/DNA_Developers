using DNA.Domain.Models.Cadastros.Pessoas;

namespace DNA.Domain.Interfaces.Cadastros.Pessoas.Clientes
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Cliente GetByEmail(string email);
    }
}