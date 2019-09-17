using System.ComponentModel.DataAnnotations;

namespace DNA.CrossCutting.Identity.Models.AccountViewModels
{
    public class LoginWith2faViewModel
    {
        [Required]
        [StringLength(7, ErrorMessage = "O {0} deve ter pelo menos {2} e no máximo {1} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Text)]
        [Display(Name = "Código de autenticação")]
        public string TwoFactorCode { get; set; }

        [Display(Name = "Lembrar desta maquina")]
        public bool RememberMachine { get; set; }
 
        public bool RememberMe { get; set; }
    }
}
