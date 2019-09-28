using DNA.Domain.Models.Cadastros.Pessoas;

namespace DNA.Domain.Interfaces.Cadastros.Pessoas.Empregados
{
    public interface IEmpregadoRepository : IRepository<Empregado>
    {
        Empregado GetByNome(string nome);
    }
}
