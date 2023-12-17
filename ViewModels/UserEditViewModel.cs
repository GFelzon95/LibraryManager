using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryManager.ViewModels
{
    public class UserEditViewModel
    {
        public string Id { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        public string UserRole { get; set; }

        public IEnumerable<IdentityRole> Roles { get; set; }
    }
}