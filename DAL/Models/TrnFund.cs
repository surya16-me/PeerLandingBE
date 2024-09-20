using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    [Table("trn_fund")]
    public class TrnFund
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required]
        [ForeignKey("Loan")]
        [Column("loan_id")]
        public string LoanId { get; set; }
        [Required]
        [ForeignKey("User")]
        [Column("lender_id")]
        public string LenderId { get; set; }
        [Required(ErrorMessage = "Loan amount is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Amount must be a positive value")]
        [Column("amount")]
        public decimal Amount { get; set; }
        [Required]
        [Column("funded_at")]
        public DateTime FundedAt { get; set; } = DateTime.UtcNow;
        public MstUser User { get; set; }
        public MstLoans Loan { get; set; }
    }
}
