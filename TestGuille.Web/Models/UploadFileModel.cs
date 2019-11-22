using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TestGuille.Data.Enum;

namespace TestGuille.Web.Models
{
    public class UploadFileModel
    {
        [Key, Required, MaxLength(50)]
        public int Id { get; set; }
        public DateTime UploadDate { get; set; }
        [Required]
        public FormatTypeEnum FormatType { get; set; }

    }
}