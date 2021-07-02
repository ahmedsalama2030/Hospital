using Core.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Entities
{
    public class Department : BaseEntity
    {

        public string Name { get; set; }
        public string NameAr { get; set; }
        public string description { get; set; }
        public string descriptionAr { get; set; }
        public string PhotoMain { get; set; }
         public Guid HospitalId { get; set; }
        public Hospital Hospital { get; set; }
        public ICollection<DepartmentService> DepartmentServices { get; set; }
        public ICollection<Doctor> Doctors { get; set; }
        public ICollection<DepartmentImages> DepartmentImages { get; set; }

    }
}
