using DNA.Domain.Core.Commands;
using System;

namespace DNA.Domain.Commands.Cadastros.Producao.Produto
{
    public abstract class CategoriaCommand : Command
    {
        public Guid Id { get; protected set; }

        public string Descricao { get; protected set; }

    }
}
