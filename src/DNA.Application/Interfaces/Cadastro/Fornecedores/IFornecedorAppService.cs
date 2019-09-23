using DNA.Application.EventSourcedNormalizers.Cadasrtro.Fornecedores;
using DNA.Application.ViewModels.Cadastro.Fornecedores;
using System;
using System.Collections.Generic;

namespace DNA.Application.Interfaces.Cadastro.Fornecedores
{
    public interface IFornecedorAppService : IDisposable
    {
        void Register(FornecedorViewModel fornecedorViewModel);
        IEnumerable<FornecedorViewModel> GetAll();

        FornecedorViewModel  GetById(Guid id);
        void Update(FornecedorViewModel fornecedorViewModel);
        void Remove(Guid id);
        IList<FornecedorHistoryData> GetAllHistory(Guid id);
    }
}
