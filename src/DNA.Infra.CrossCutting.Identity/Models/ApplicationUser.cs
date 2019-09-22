using Microsoft.AspNetCore.Identity;
using System;

namespace DNA.CrossCutting.Identity.Models
{  
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
