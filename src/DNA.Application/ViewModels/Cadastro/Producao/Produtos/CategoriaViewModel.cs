using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DNA.Application.ViewModels.Cadastro.Producao.Produtos
{
    public class CategoriaViewModel
    {

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo da descrição é obrigatório")]
        [MinLength(2)]
        [MaxLength(200)]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }

    }
}
