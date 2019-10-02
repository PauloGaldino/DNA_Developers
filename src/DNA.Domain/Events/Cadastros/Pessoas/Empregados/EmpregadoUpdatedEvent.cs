using DNA.Domain.Core.Events;
using System;

namespace DNA.Domain.Events.Cadastros.Pessoas.Empregados
{
    public class EmpregadoUpdatedEvent : Event
    {
        public EmpregadoUpdatedEvent(Guid id, string nome, string sobrenome, string cargo, DateTime dataAdmissao, DateTime dataNascimento)
        {
            Id = id;
            Nome = nome;
            Sobrenome = sobrenome;
            DataAdmissao = dataAdmissao;
            AggregateId = id;
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Cargo { get; private set; }
        public DateTime DataAdmissao { get; private set; }
        public DateTime DataNascimento { get; set; }
    }
}
