using DNA.Application.EventSourcedNormalizers.Cadastro.Categorias;
using DNA.Application.ViewModels.Cadastro.Categorias;
using System;
using System.Collections.Generic;

namespace DNA.Application.Interfaces.Cadastro.Categorias
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
