using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    [Table("mst_loans")]
    public class MstLoans
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required(ErrorMessage = "Borrower ID is required")]
        [ForeignKey("User")]
        [Column("borrower_id")]
        public string BorrowerId { get; set; }

        [Required(ErrorMessage = "Loan amount is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Amount must be a positive value")]
        [Column("amount")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Interest rate is required")]
        [Range(0, 100, ErrorMessage = "Interest rate must be between 0 and 100")]
        [Column("interest_rate")]
        public decimal InterestRate { get; set; }

        [Required(ErrorMessage = "Duration is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Duration must be a positive integer")]
        [Column("duration_in_months")]
        public int Duration { get; set; }

        [Required(ErrorMessage = "Loan status is required")]
        [StringLength(50, ErrorMessage = "Status can't exceed 50 characters")]
        [Column("status")]
        public string Status { get; set; }

        [Required]
        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Required]
        [Column("last_updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation Property
        public MstUser User { get; set; }
        public List<TrnFund> MstFunds { get; set; } = new List<TrnFund>();
        public List<TrnRepayment> TrnRepayments { get; set; } = new List<TrnRepayment>();
    }
}
