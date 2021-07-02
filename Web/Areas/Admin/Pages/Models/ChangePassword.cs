using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Admin.Pages.Models
{
    public class ChangePassword
    {
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "passwordNotCorrect")]
        public string RePassword { get; set; }
    }
}
