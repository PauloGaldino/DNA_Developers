using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DNA.Application.ViewModels.Cadastro.Fornecedores
{
   public class FornecedorViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo do nome da Companhia é obrigatório")]
        [MinLength(2)]
        [MaxLength(200)]
        [DisplayName("Nome da Companhia")]
        public string NomeCompanhia { get;  set; }

        [Required(ErrorMessage = "O campo do nome do Contato é obrigatório")]
        [MinLength(2)]
        [MaxLength(200)]
        [DisplayName("Nome do Contato")]
        public string NomeContato { get;  set; }

        [Required(ErrorMessage = "O campo do nome é obrigatório")]
        [MinLength(2)]
        [MaxLength(200)]
        [DisplayName("Titulo do Contato")]
        public string TituloContato { get;  set; }

        [Required(ErrorMessage = "O campo do numero do Telefone é obrigatório")]
        [DisplayName("Telefone")]
        public string Telefone { get;  set; }

        [Required(ErrorMessage = "O campo do E-mail é obrigatório")]
        [MinLength(2)]
        [MaxLength(200)]
        [DisplayName("Endereço do E-mail")]
        public string EnderecoEmail { get;  set; }

        [Required(ErrorMessage = "O campo do Endereço é obrigatório")]
        [MinLength(2)]
        [MaxLength(200)]
        [DisplayName("Endereço")]
        public string Endereco { get;  set; }

        [Required(ErrorMessage = "O campo da Cidade é obrigatório")]
        [MinLength(2)]
        [MaxLength(200)]
        [DisplayName("Cidade")]
        public string Cidade { get;  set; }

        [Required(ErrorMessage = "O campo do Estado é obrigatório")]
        [MinLength(2)]
        [MaxLength(150)]
        [DisplayName("Estado")]
        public string Estado { get;  set; }

        [Required(ErrorMessage = "O campo do Pais é obrigatório")]
        [MinLength(2)]
        [MaxLength(150)]
        [DisplayName("Pais")]
        public string Pais { get;  set; }
    }
}
