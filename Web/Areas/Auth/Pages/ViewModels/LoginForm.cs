using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Auth.Pages.ViewModels
{
    public class LoginForm
    {
        [Required(ErrorMessage = "field-required")]
        public string Password { get; set; }
        [Required(ErrorMessage = "field-required")]
        public string Email { get; set; }
    }
}
