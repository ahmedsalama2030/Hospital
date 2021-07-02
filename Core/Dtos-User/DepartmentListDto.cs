using Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace  Core.Dtos_User
{
   public  class DepartmentListDtoUser : BaseEntity
    {
        public string Name { get; set; }
        public string NameAr { get; set; }
        public string description { get; set; }
        public string descriptionAr { get; set; }
         public string HospitalId { get; set; }
        public string HospitalName { get; set; }
        public string HospitalNameAr { get; set; }
    }
}
