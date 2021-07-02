using Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Entities
{
    public class GeneralSetting : BaseEntity
    {
        public string SiteName { get; set; }
        public string SiteNameAr { get; set; }
        public string AdminSiteName { get; set; }
        public string AdminSiteNameAr { get; set; }
        public string SiteLogoPath { get; set; }
        public string ManegerHead { get; set; }
        public string ManegerHeadAr { get; set; }
        public string ManegerWord { get; set; }
        public string ManegerWordAr { get; set; }
        public string ManegerName { get; set; }
        public string ManegerNameAr { get; set; }
        public string ManegerPhotoPath { get; set; }
        public string VideoPath { get; set; }
        public string AboutUsDescription { get; set; }
        public string AboutUsDescriptionAr { get; set; }
        public string Value { get; set; }
        public string ValueAr { get; set; }
        public string Vision { get; set; }
        public string VisionAr { get; set; }
        public string Message { get; set; }
        public string MessageAr { get; set; }
        public string History { get; set; }
        public string HistoryAr { get; set; }
        public string Address { get; set; }
        public string AddressAr { get; set; }
        public string Email { get; set; }
        public string PhoneNumbermain { get; set; }
        public string PhoneNumberSecond { get; set; }
        public string PhoneNumberThird { get; set; }
        public string MapPath { get; set; }
        public string AboutUs { get; set; }
        public string AboutUsAr { get; set; }
        public string FacebookPath { get; set; }
        public string TwitterPath { get; set; }
        public string YoutubePath { get; set; }
        public string LinkedInPath { get; set; }
        public string JobTimeDetails { get; set; }

    }
}