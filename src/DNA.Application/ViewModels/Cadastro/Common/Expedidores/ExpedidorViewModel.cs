using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DNA.Application.ViewModels.Cadastro.Common.Expedidores
{
    public class ExpedidorViewModel
    {
        [Key]
        public Guid Id  { get; set; }
       
        [Required(ErrorMessage ="O campo do Nome ca compnhia precisa ser preenchido")]
        [MinLength(2)]
        [MaxLength(200)]
        [DisplayName("Nome da Companhia")]
        public string CompanhiaNome { get; set; }

        [Required(ErrorMessage ="O campo do telefone precisa ser preenchido")]
        [MinLength(2)]
        [MaxLength(50)]
        [DisplayName("Telefone")]
        public string Telefone { get; set; }
    }
}
