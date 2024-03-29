﻿using DNA.Domain.Core.Events;
using System;

namespace DNA.Domain.Events.Cadastros.Pessoas.Clientes
{
    public class ClienteUpdatedEvent : Event
    {
        public ClienteUpdatedEvent(Guid id, string nome, string email, DateTime dataNascimento)
        {
            Id = id;
            Nome = nome;
            Email = email;
            DataNascimento = dataNascimento;
            AggregateId = id;
        }
        public Guid Id { get; set; }

        public string Nome { get; private set; }

        public string Email { get; private set; }

        public DateTime DataNascimento { get; private set; }
    }
}