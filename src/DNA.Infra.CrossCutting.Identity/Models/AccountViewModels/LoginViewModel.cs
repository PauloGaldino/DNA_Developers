using System.ComponentModel.DataAnnotations;

namespace DNA.CrossCutting.Identity.Models.AccountViewModels
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Lembre de mim ? ")]
        public bool RememberMe { get; set; }
    }
}
