using DNA.Domain.Core.Commands;
using System;

namespace DNA.Domain.Commands.Cadastros.Common.Expedidores
{
    public abstract class ExpedidorCommand : Command
    {
        public Guid Id { get; protected set; }
        public string CompanhiaNome { get; protected set; }
        public string Telefone { get; protected set; }
    }
}
