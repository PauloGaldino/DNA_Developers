using DNA.Domain.Models.Cadastros.Common.Fornecedores;

namespace DNA.Domain.Interfaces.Cadastros.Common.Fornecedores
{
    public interface IFornecedorRepository : IRepository<Fornecedor>
    {
        Fornecedor GetByNomeCompanhia(string nomeCompanhia);
    }
}