using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalFinanceProjects.API.Models
{
    [Table("tbl_t_TransactionImage")]
    public class TransactionImageModel
    {
        [Key]
        public int ImageId { get; set; }
        [Required]
        public int TransactionId { get; set; }
        public TransactionModel Transaction { get; set; }

        public string ImageUrl { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }
    }
}
