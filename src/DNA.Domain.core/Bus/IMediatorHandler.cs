using DNA.Domain.Core.Commands;
using DNA.Domain.Core.Events;
using System.Threading.Tasks;

namespace DNA.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
