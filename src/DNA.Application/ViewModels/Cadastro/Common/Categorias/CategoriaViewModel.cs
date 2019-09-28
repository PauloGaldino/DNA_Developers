using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DNA.Application.ViewModels.Cadastro.Common.Categorias
{ 
    public class CategoriaViewModel
    {

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo do nome é obrigatório")]
        [MinLength(2)]
        [MaxLength(200)]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo da descrição é obrigatório")]
        [MinLength(2)]
        [MaxLength(200)]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }

    }
}
