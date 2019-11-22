using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestGuille.Data.Enum;

namespace TestGuille.Data.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string NroInvoice { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required, StringLength(3, MinimumLength = 3)]
        public string CurrencyCode { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public StatusEnum Status { get; set; }
    }
}
