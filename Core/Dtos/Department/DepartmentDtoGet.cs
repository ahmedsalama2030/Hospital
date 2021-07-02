using Core.Common;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Dtos.Department
{
    public class DepartmentDtoGet : BaseEntity
    {
        [Required(ErrorMessage = "field-required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "field-required")]
        public string NameAr { get; set; }
        [Required(ErrorMessage = "field-required")]
        public string description { get; set; }
        [Required(ErrorMessage = "field-required")]
        public string descriptionAr { get; set; }
        public Guid HospitalId { get; set; }

 
    }
}
