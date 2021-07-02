using Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Dtos.Doctor
{
    public class DoctorDtoList:BaseEntity
    {
        public string Name { get; set; }

        public string NameAr { get; set; }
        public string Special { get; set; }
        public string SpecialAr { get; set; }
        public bool IsConsultant { get; set; }
        public string Degree { get; set; }
        public string DegreeAr { get; set; }
        public string University { get; set; }

        public string UniversityAr { get; set; }
        public string Job { get; set; }
        public string JobAr { get; set; }

        public Guid DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentNameAr { get; set; }
    }
}
