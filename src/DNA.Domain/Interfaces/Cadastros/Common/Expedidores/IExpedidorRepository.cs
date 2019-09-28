using DNA.Domain.Models.Cadastros.Common.Expedidores;

namespace DNA.Domain.Interfaces.Cadastros.Common.Expedidores
{
    public interface IExpedidorRepository : IRepository<Expedidor>
    {
        Expedidor GetByNomeCompanhia(string companhiaNome);
    }
}
