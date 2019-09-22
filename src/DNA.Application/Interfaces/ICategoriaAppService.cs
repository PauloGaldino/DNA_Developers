using DNA.Application.EventSourcedNormalizers;
using DNA.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace DNA.Application.Interfaces
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
