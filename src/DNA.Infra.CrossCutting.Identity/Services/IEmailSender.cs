using System.Threading.Tasks;

namespace DNA.CrossCutting.Identity.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
