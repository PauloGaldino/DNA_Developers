using DNA.Application.EventSourcedNormalizers.Cadastro.Common.Categorias;
using DNA.Application.ViewModels.Cadastro.Common.Categorias;
using System;
using System.Collections.Generic;

namespace DNA.Application.Interfaces.Cadastro.Common.Categorias
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
