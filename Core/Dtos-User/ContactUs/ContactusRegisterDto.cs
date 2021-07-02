using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Core.Dtos_User.ContactUs
{
    public class ContactusRegisterDto
    {
        [Required(ErrorMessage = "field-required")]

        public string Name { get; set; }
        [Required(ErrorMessage = "field-required")]

        public string Email { get; set; }
        [Required(ErrorMessage = "field-required")]

        public string Phone { get; set; }
        [Required(ErrorMessage = "field-required")]

        public string Message { get; set; }
    }
}
