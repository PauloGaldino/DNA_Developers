using System.ComponentModel.DataAnnotations;

namespace DNA.CrossCutting.Identity.Models.AccountViewModels
{
    public class LoginWithRecoveryCodeViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Código de recuperação")]
        public string RecoveryCode { get; set; }
    }
}
