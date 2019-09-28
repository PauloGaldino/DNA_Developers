using System;

namespace DNA.Application.EventSourcedNormalizers.Cadastro.Pessoas.Empregados
{
    public class EmpregadoHistoryData
    {
        public string Action { get; set; }
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Cargo { get; set; }
        public string DataAdmissao { get; set; }
        public string DataNascimento { get; set; }
        public string When { get; set; }
        public string Who { get; set; }
    }
}
