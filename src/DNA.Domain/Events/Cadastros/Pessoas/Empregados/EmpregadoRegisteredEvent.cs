using DNA.Domain.Core.Events;
using System;

namespace DNA.Domain.Events.Cadastros.Pessoas.Empregados
{
     public class EmpregadoRegisteredEvent :Event
    {
        public EmpregadoRegisteredEvent(Guid id, string nome, string sobrenome, string cargo,DateTime dataAdmissao, DateTime dataNascimento)
        {
            Id = id;
            Nome = nome;
            Sobrenome = sobrenome;
            DataAdmissao = dataAdmissao;
            DataNascimento = dataNascimento;
            AggregateId = id;
        }

        public Guid Id { get; set; }
        public string  Nome { get; private set; }
        public string Sobrenome { get; private set; }
        public string Cargo { get; private set; }
        public DateTime DataAdmissao { get; private set; }
        public DateTime DataNascimento { get; set; }    
    }
}
