using DNA.Domain.Core.Models;
using System;

namespace DNA.Domain.Models.Cadastros.Common.Expedidores
{
    public class Expedidor :Entity
    {
        public Expedidor(Guid id, string companhiaNome, string telefone)
        {
            Id = id;
            CompanhiaNome = companhiaNome;
            Telefone = telefone;
        }
        protected Expedidor(){}

        public string CompanhiaNome { get;private set; }
        public string Telefone { get; private set; }
    }
}
