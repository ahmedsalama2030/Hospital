using Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Dtos_User.Appointment
{
    public class AppointmentGetDto : BaseEntity
    {
        [Required(ErrorMessage = "field-required")]
        public string PatientName { get; set; }
        [Required(ErrorMessage = "field-required")]
        [EmailAddress(ErrorMessage = "email-error")]
        public string Email { get; set; }
        [Required(ErrorMessage = "field-required")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "field-required")]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "field-required")]
        public string Note { get; set; }
        [Required(ErrorMessage = "field-required")]

        public string ClincName { get; set; }
    }
}
