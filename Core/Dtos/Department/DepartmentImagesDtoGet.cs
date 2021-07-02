using Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Dtos.Department
{
   public  class DepartmentImagesDtoGet : BaseEntity
    {
        [Required(ErrorMessage = "field-required")]
        public string Path { get; set; }
        public bool isMain { get; set; }
        public Guid DepartmentId { get; set; }
     }
}
