using Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Entities
{
    public class Hospital : BaseEntity
    {
        public string Name { get; set; }
        public string NameAr { get; set; }
        public string description { get; set; }
        public string descriptionAr { get; set; }
        public ICollection<Department> Departments { get; set; }
    }
}
