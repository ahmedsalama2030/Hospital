using Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Dtos.hospital
{
   public  class HospitalDtoGet : BaseEntity
    {
        [Required(ErrorMessage = "field-required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "field-required")]
        public string NameAr { get; set; }
        [Required(ErrorMessage = "field-required")]
        public string description { get; set; }
        [Required(ErrorMessage = "field-required")]
        public string descriptionAr { get; set; }
     }
}
