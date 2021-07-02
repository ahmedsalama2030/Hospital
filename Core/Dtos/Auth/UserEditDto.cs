using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Dtos.Auth
{
    public class UserEditDto
    {
        [Required(ErrorMessage = "field-required")]
        public Guid Id { get; set; }

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
         
    }
}
