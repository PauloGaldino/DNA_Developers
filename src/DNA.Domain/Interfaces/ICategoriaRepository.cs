using DNA.Domain.Models;

namespace DNA.Domain.Interfaces
{
    public interface ICategoriaRepository: IRepository<Categoria>
    {
        Categoria GetByNome(string descricao);
        Categoria GetByDescricao(string descricao);
      
    }
}
