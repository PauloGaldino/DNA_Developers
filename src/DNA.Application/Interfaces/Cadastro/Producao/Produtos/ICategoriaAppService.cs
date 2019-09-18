using DNA.Application.EventSourcedNormalizers.Cadasrtro.Producao.Produtos;
using DNA.Application.ViewModels.Cadastro.Producao.Produtos;
using System;
using System.Collections.Generic;

namespace DNA.Application.Interfaces.Cadastro.Producao.Produtos
{
    public interface ICategoriaAppService : IDisposable
    {
        void Register(CategoriaViewModel categoriaViewModel);
        IEnumerable<CategoriaViewModel> GetAll();
        CategoriaViewModel GetById(Guid id);
        void Update(CategoriaViewModel categoriaViewModel);
        void Remove(Guid id);
        IList<CategoriaHistoryData> GetAllHistory(Guid id);
    }
}
