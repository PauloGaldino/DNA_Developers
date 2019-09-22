using DNA.Domain.Core.Commands;
using System;

namespace DNA.Domain.Commands
{
    public abstract class CategoriaCommand : Command
    {
        public Guid Id { get; protected set; }

        public string Nome { get; protected set; }
        public string Descricao { get; protected set; }

    }
}
