using Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Entities
{
    public class CommonQuestion : BaseEntity
    {

        public string Title { get; set; }
        public string TitleAr { get; set; }
        public string description { get; set; }
        public string descriptionAr { get; set; }
        }
}