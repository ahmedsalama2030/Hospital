using Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Dtos.Auth
{
    public class UserRegisterDto : BaseEntity
    {
        [Required(ErrorMessage = "field-required")]

        public string UserName { get; set; }
        [Required(ErrorMessage = "field-required")]

        public string FirstName { get; set; }
        [Required(ErrorMessage = "field-required")]

        public string LastName { get; set; }
        [Required(ErrorMessage = "field-required")]

        public string MiddelName { get; set; }
        [Required(ErrorMessage = "field-required")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "field-required")]
        [EmailAddress(ErrorMessage = "email-error")]
        public string Email { get; set; }
        [Required(ErrorMessage = "field-required")]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "passwordNotCorrect")]
        public string RePassword { get; set; }

    }
}
