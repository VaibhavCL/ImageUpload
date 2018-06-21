using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ImageWebApplication.Models
{
    public class ContentViewModel
    {
        [Key]
        public int ImageId { get; set; }

        public string Title { get; set; }
        [DisplayName("UploadFile")]

        public string ImagePath { get; set; }
    }
}