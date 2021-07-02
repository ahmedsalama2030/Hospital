using Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Dtos.clinics
{
    public class ClinicSchedulDtoGet : BaseEntity
    {
        [Required(ErrorMessage = "Please enter this filed")]

        public string ClinicName { get; set; }
        [Required(ErrorMessage = "Please enter this filed")]
        public string ClinicNameAr { get; set; }
        [Required(ErrorMessage = "Please enter this filed")]
        public string TimeFrom { get; set; }
        [Required(ErrorMessage = "Please enter this filed")]
         public string TimeTo { get; set; }
        public bool IsSaturday { get; set; }
        public bool IsSunday { get; set; }
        public bool IsMonday { get; set; }
        public bool IsTuesday { get; set; }
        public bool IsWednesday { get; set; }
        public bool IsThursday { get; set; }
        public bool IsFriday { get; set; }
    }
}