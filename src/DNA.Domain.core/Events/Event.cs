using MediatR;
using System;

namespace DNA.Domain.Core.Events
{
    public abstract class Event : Message, INotification
    {
        /// <summary>
        /// Classe responsável por dispara os eventos
        /// </summary>
        public DateTime Timestamp { get; private set; }

        protected Event()
        {
            Timestamp = DateTime.Now;
        }
    }
}