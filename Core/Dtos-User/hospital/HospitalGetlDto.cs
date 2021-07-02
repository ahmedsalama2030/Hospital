using Core.Common;
using Core.Dtos_User.Department;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Dtos_User.hospital
{
    public class HospitalGetlDto:BaseEntity
    {
        public string Name { get; set; }
        public string NameAr { get; set; }
        public string description { get; set; }
        public string descriptionAr { get; set; }
        public IEnumerable<deparmentMiniDto> Departments { get; set; }
    }
}
