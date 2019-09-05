using System.Collections.Generic;
using System.Security.Claims;

namespace DNA.Domain.Interfaces.Cadastros.Pessoas.Usuarios
{
    public interface IUser
    {
        string Name { get; }
        bool IsAuthenticated();
        IEnumerable<Claim> GetClaimsIdentity();
    }
}
