using Core.Common;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Dtos_User.Department
{
   public class DepartmentDetailDto:BaseEntity
    {
        public string Name { get; set; }
        public string NameAr { get; set; }
        public string description { get; set; }
        public string descriptionAr { get; set; }
        public string HospitalName { get; set; }
        public string HospitalNameAr { get; set; }
        public IEnumerable<DepartmentService> DepartmentServices { get; set; }
        public IEnumerable<DepartmentImages> DepartmentImages { get; set; }
    }
}
