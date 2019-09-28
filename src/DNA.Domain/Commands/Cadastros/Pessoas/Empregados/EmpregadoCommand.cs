using DNA.Domain.Core.Commands;
using System;

namespace DNA.Domain.Commands.Cadastros.Pessoas.Empregados
{
    public abstract class EmpregadoCommand : Command
    {
        public Guid Id { get; protected set; }
        public string Nome { get; protected set; }
        public string Sobrenome { get; protected set; }
        public string Cargo { get; protected set; }
        public DateTime DataAdmissao { get; protected set; }
        public DateTime DataNascimento { get; protected set; }
    }
}
