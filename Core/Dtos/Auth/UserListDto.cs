using Core.Common;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Dtos.Auth
{
 public    class UserListDto:BaseEntity
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
         public string LastName { get; set; }
        public string MiddelName { get; set; }
        public string PhoneNumber { get; set; }
        public string Name { get; set; }
        public string rolesName { get; set; }

         

    }
}
