using DNA.Application.EventSourcedNormalizers.Cadastro.Pessoas.Empregados;
using DNA.Application.ViewModels.Cadastro.Pessoas.Empregados;
using System;
using System.Collections.Generic;

namespace DNA.Application.Interfaces.Cadastro.Pessoas.Empregados
{
    public interface IEmpregadoAppService : IDisposable
    {
        void Register(EmpregadoViewModel empregadoViewModel);
        IEnumerable<EmpregadoViewModel> GetAll();
        EmpregadoViewModel GetById(Guid id);
        void Update(EmpregadoViewModel clienteViewModel);
        void Remove(Guid id);
        IList<EmpregadoHistoryData> GetAllHistory(Guid id);
    }
}
