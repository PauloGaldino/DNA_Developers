using DNA.Domain.Models.Cadastros.Producao;

namespace DNA.Domain.Interfaces.Cadastros.Producao.Produtos
{
    public interface ICategoriaRepository: IRepository<Categoria>
    {
        Categoria GetByDescricao(string descricao);
    }
}
