using DNA.Domain.Core.Commands;
using DNA.Domain.Core.Events;
using System.Threading.Tasks;

namespace DNA.Domain.Core.Bus
{
    /// <summary>
    /// Classe responsável por processar os COmmands e os Events.
    /// </summary>
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
