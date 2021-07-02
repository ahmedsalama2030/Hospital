using Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Entities
{
    public class ClinicSchedul : BaseEntity
    {

        public string ClinicName { get; set; }
        public string ClinicNameAr { get; set; }
        public string TimeFrom { get; set; }
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
