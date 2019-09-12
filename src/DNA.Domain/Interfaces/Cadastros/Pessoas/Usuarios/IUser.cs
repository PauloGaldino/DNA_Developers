using System.Collections.Generic;
using System.Security.Claims;

namespace DNA.Domain.Interfaces.Cadastros.Pessoas.Usuarios
{
    public interface IUser
    {
        string Nome { get; }
        bool IsAuthenticated();
        IEnumerable<Claim> GetClaimsIdentity();
    }
}
