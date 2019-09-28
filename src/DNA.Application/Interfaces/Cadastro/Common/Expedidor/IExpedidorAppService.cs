using DNA.Application.EventSourcedNormalizers.Cadastro.Common.Expedidores;
using DNA.Application.ViewModels.Cadastro.Common.Expedidores;
using System;
using System.Collections.Generic;

namespace DNA.Application.Interfaces.Cadastro.Common.Expedidor
{
    public interface IExpedidorAppService : IDisposable
    {
        void Register(ExpedidorViewModel expdidorViewModel);
        IEnumerable<ExpedidorViewModel> GetAll();
        ExpedidorViewModel GetById(Guid id);
        void Update(ExpedidorViewModel expedidorrViewModel);
        void Remove(Guid id);
        IList<ExpedidorHistoryData> GetAllHistory(Guid id);
    }
}
