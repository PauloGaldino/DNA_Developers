﻿using System.ComponentModel.DataAnnotations;

namespace DNA.Application.EventSourcedNormalizers.Cadastro.Common.Categorias
{
    public class CategoriaHistoryData
    {
        public string Action { get; set; }
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string When { get; set; }
        public string Who { get; set; }
    }
}
