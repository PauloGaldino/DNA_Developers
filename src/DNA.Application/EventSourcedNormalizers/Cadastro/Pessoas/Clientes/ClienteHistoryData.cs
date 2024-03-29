﻿using System.ComponentModel.DataAnnotations;

namespace DNA.Application.EventSourcedNormalizers.Cadastro.Pessoas.Clientes
{
    public class ClienteHistoryData
    {
        public string Action { get; set; }
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string DataNascimento { get; set; }
        public string When { get; set; }
        public string Who { get; set; }
    }
}