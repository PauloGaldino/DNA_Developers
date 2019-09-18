using DNA.Application.EventSourcedNormalizers.Cadastro.Pessoas.Clientes;
using DNA.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace DNA.Application.Interfaces.Cadastro.Pessoas.Clientes
{
    public interface IClienteAppService : IDisposable
    {
        void Register(ClienteViewModel clienteViewModel);
        IEnumerable<ClienteViewModel> GetAll();
        ClienteViewModel GetById(Guid id);
        void Update(ClienteViewModel clienteViewModel);
        void Remove(Guid id);
        IList<ClienteHistoryData> GetAllHistory(Guid id);
    }
}
