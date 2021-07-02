using Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Entities
{
    public class Slider : BaseEntity
    {
        public string Path { get; set; }
        public string Text { get; set; }
        public string TextAr { get; set; }
        public string Title { get; set; }
        public string TitleAr { get; set; }

    }
}
