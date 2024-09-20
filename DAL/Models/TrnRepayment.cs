using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    [Table("trn_repayment")]
    public class TrnRepayment
    {
        [Key]
        public string Id { get; set; }
        [Required]
        [ForeignKey("Loan")]
        public string LoanId { get; set; }
        [Required(ErrorMessage = "Loan amount is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Amount must be a positive value")]
        [Column("amount")]
        public decimal Amount { get; set; }
        [Required]
        [Column("paid_at")]
        public DateTime PaidAt { get; set; } = DateTime.UtcNow;
        public MstLoans Loan { get; set; }
    }
}
