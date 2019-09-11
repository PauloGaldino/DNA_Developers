using DNA.Domain.Core.Events;
using System;
using FluentValidation.Results;

namespace DNA.Domain.Core.Commands
{
    public abstract class Command : Message
    {
        /// <summary>
        /// Classe responsável por alteerar os estados das entidades
        /// </summary>
        public DateTime Timestamp { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        protected Command()
        {
            Timestamp = DateTime.Now;
        }

        public abstract bool IsValid();
    }
}