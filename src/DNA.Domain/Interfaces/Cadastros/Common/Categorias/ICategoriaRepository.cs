using DNA.Domain.Models.Cadastros.Common.Categorias;

namespace DNA.Domain.Interfaces.Cadastros.Common.Categorias
{
    public interface ICategoriaRepository: IRepository<Categoria>
    {
        Categoria GetByNome(string descricao);
        Categoria GetByDescricao(string descricao);
      
    }
}
