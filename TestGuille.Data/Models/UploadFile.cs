using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestGuille.Data.Enum;

namespace TestGuille.Data.Models
{
    public class UploadFile
    {
        [Key]
        public int Id { get; set; }
        public DateTime UploadDate { get; set; }
        [Required]
        public FormatTypeEnum FormatType { get; set; }
        public List<Transaction> Transactions {get;set; }

    }
}
