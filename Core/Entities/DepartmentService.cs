using Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Entities
{
    public class DepartmentService : BaseEntity
    {
        public string Name { get; set; }
        public string NameAr { get; set; }
        public Guid DepartmentId { get; set; }
        public Department Department { get; set; }



    }
}