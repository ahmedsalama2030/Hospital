using Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Entities
{
    public class DepartmentImages: BaseEntity
    {
        
         public string Path { get; set; }
        public bool isMain { get; set; }
        public Guid DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
