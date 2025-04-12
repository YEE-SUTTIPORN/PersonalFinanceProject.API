using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalFinanceProjects.API.Models
{
    [Table("tbl_t_Transaction")]
    public class TransactionModel
    {
        [Key]
        public int TransactionId { get; set; }
        [Required]
        public int UserId { get; set; }
        public UserModel User { get; set; } = new UserModel();

        [Required]
        public int CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public CategoryModel Category { get; set; }

        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
        public string TransactionType { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public ICollection<TransactionImageModel> TransactionImages { get; set; }

    }
}
