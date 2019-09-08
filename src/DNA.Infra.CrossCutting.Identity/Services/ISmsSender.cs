using System.Threading.Tasks;

namespace DNA.CrossCutting.Identity.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
