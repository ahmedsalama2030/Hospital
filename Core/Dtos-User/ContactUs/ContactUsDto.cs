using Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Dtos_User.ContactUs
{
   public  class ContactUsDto : BaseEntity
    {
        public string StreetAr { get; set; }
        public string Email { get; set; }
        public string PhoneNumbermain { get; set; }

        public string MapPath { get; set; }
        public string AboutUs { get; set; }
        public string AboutUsAr { get; set; }
        public string Address { get; set; }
        public string AddressAr { get; set; }

    }
}