using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DNA.Application.ViewModels
{
    public class ClienteViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The Name is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "The E-mail is Required")]
        [EmailAddress]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The BirthDate is Required")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        [DisplayName("Data Nascimento")]
        public DateTime DataNascimento { get; set; }
    }
}
