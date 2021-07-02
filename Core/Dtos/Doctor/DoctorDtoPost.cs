using Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Dtos.Doctor
{
    public class DoctorDtoPost
    {
        [Required(ErrorMessage = "field-required")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "field-required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "field-required")]
        public string NameAr { get; set; }
        [Required(ErrorMessage = "field-required")]
        public string Special { get; set; }
        [Required(ErrorMessage = "field-required")]
        public string SpecialAr { get; set; }
        public bool IsConsultant { get; set; }
        [Required(ErrorMessage = "field-required")]
        public string Degree { get; set; }
        [Required(ErrorMessage = "field-required")]
        public string DegreeAr { get; set; }
        [Required(ErrorMessage = "field-required")]
        public string University { get; set; }
        [Required(ErrorMessage = "field-required")]
        public string UniversityAr { get; set; }
        [Required(ErrorMessage = "field-required")]
        public string Job { get; set; }
        [Required(ErrorMessage = "field-required")]
        public string JobAr { get; set; }
        [Required(ErrorMessage = "field-required")]
        public Guid DepartmentId { get; set; }
        public string PhotoPath { get; set; }

    }
}

