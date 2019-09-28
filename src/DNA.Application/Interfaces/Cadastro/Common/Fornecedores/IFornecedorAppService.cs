using DNA.Application.EventSourcedNormalizers.Cadasrtro.Common.Fornecedores;
using DNA.Application.ViewModels.Cadastro.Common.Fornecedores;
using System;
using System.Collections.Generic;

namespace DNA.Application.Interfaces.Cadastro.Common.Fornecedores
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
