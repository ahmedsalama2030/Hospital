using Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Dtos_User.Department
{
    public class deparmentMiniDto : BaseEntity
    {
        public string Name { get; set; }
        public string NameAr { get; set; }
        public string description { get; set; }
        public string descriptionAr { get; set; }
        
         
    }
}