using Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Entities
{
    public class Appointment : BaseEntity
    {
         public string PatientName { get; set; }
         public string Email { get; set; }
         public string PhoneNumber { get; set; }
         public DateTime DateOfBirth { get; set; }
         public string Note { get; set; }
         public string ClincName { get; set; }

    }
}
